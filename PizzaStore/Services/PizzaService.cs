using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LinqKit;

namespace PizzaStore.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IIngredientService _ingredientService;

        public PizzaService(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment, IIngredientService ingredientService)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _ingredientService = ingredientService;
        }

        public IEnumerable<Pizza> GetAllPizzas()
        {
            return _context.Pizzas.Include(p => p.Ingredients).ToList();
        }

        public PizzaCreateViewModel PrepareCreateViewModel()
        {
            PizzaCreateViewModel model = new PizzaCreateViewModel();

            List<CheckBoxModel> ChkItem = new List<CheckBoxModel>();

            foreach (Ingredient ingredient in _ingredientService.GetAllIngredients())
            {
                ChkItem.Add(new CheckBoxModel { Id = ingredient.IngredientId, LabelName = ingredient.Name, IsChecked = false });
            }

            model.CheckBoxItems = ChkItem;
            return model;
        }

        public IEnumerable<Pizza> SearchPizzas(PizzaSearchViewModel searchViewModel)
        {
            var predicate = PredicateBuilder.New<Pizza>(true);

            if (!string.IsNullOrEmpty(searchViewModel.Name))
            {
                predicate = predicate.And(x => x.Name.Contains(searchViewModel.Name));
            }

            if (searchViewModel.MinPrice != null)
            {
                predicate = predicate.And(x => x.Price >= searchViewModel.MinPrice);
            }

            if (searchViewModel.MaxPrice != null)
            {
                predicate = predicate.And(x => x.Price <= searchViewModel.MaxPrice);
            }

            foreach (var item in searchViewModel.CheckBoxItems.Where(i => i.IsChecked))
            {
                predicate = predicate.And(pizza => pizza.Ingredients.Any(ingredient => ingredient.IngredientId == item.Id));
            }

            return _context.Pizzas.Include(x => x.Ingredients).AsExpandable().Where(predicate);

        }

        public void Add(PizzaCreateViewModel model)
        {
            string uniqueFileName = GetUniqueFileName(model.ImageUrl.FileName);
            string imagesPath = Path.Combine(_hostingEnvironment.WebRootPath, "img/pizza");
            string filePath = Path.Combine(imagesPath, uniqueFileName);
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            model.ImageUrl.CopyTo(fileStream);

            Pizza newPizza = new Pizza
            {
                Price = model.Price,
                ImageUrl = uniqueFileName,
                Name = model.Name,
                Ingredients = model.CheckBoxItems
                    .Where(item => item.IsChecked)
                    .Select(item => _ingredientService.GetById(item.Id))
                    .ToList()
            };

            _context.Add(newPizza);
            _context.SaveChanges();
        }

        public Pizza GetById(int id)
        {
            return _context.Pizzas.Include(x => x.Ingredients).SingleOrDefault(x => x.PizzaId == id);
        }

        public void DeleteById(int id)
        {
            Pizza pizzadelete = GetById(id);
            _context.Remove(pizzadelete);
            _context.SaveChanges();
        }

        public PizzaEditViewModel PrepareEditViewModel(Pizza pizza)
        {
            PizzaEditViewModel pizzaEditViewModel= new PizzaEditViewModel();
            pizzaEditViewModel.Name = pizza.Name;
            pizzaEditViewModel.Price = pizza.Price;
            pizzaEditViewModel.Id = pizza.PizzaId;

            List<CheckBoxModel> ChkItem = new List<CheckBoxModel>();
            if (pizzaEditViewModel.CheckBoxItems.Count == 0 || pizzaEditViewModel.CheckBoxItems == null)
            {
                foreach (Ingredient ingredient in _ingredientService.GetAllIngredients())
                {
                    ChkItem.Add(new CheckBoxModel { Id = ingredient.IngredientId, LabelName = ingredient.Name, IsChecked = false });
                }
                pizzaEditViewModel.CheckBoxItems = ChkItem;
            }

            var ingredientIds = pizza.Ingredients.Select(x => x.IngredientId).ToList();
            pizzaEditViewModel.CheckBoxItems.ForEach(x => x.IsChecked = ingredientIds.Contains(x.Id));
            return pizzaEditViewModel;
        }

        public void Update(PizzaEditViewModel pizzaEditViewModel)
        {
            Pizza editPizza = GetById(pizzaEditViewModel.Id);
            editPizza.Name = pizzaEditViewModel.Name;
            editPizza.Price = pizzaEditViewModel.Price;
            editPizza.Ingredients = pizzaEditViewModel.CheckBoxItems
                    .Where(item => item.IsChecked)
                    .Select(item => _ingredientService.GetById(item.Id))
                    .ToList();
            if(pizzaEditViewModel.ImageUrl != null)
            {
                string uniqueFileName = GetUniqueFileName(pizzaEditViewModel.ImageUrl.FileName);
                string imagesPath = Path.Combine(_hostingEnvironment.WebRootPath, "img/pizza");
                string filePath = Path.Combine(imagesPath, uniqueFileName);
                using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                pizzaEditViewModel.ImageUrl.CopyTo(fileStream);
                editPizza.ImageUrl = uniqueFileName;
            }
            _context.Update(editPizza);
            _context.SaveChanges();
        }

        private string GetUniqueFileName(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string uniqueString = Guid.NewGuid().ToString().Substring(0, 4);
            return $"{fileNameWithoutExtension}_{uniqueString}{extension}";
        }
    }
}