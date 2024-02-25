using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Models;
using PizzaStore.Services;

namespace PizzaStore.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;
        private IIngredientService _ingredientService;

        public PizzaController(IPizzaService pizzaService, IIngredientService ingredientService)
        {
            _pizzaService = pizzaService;
            _ingredientService = ingredientService;
        }

        public IActionResult Index(PizzaSearchViewModel searchViewModel)
        {
            List<CheckBoxModel> ChkItem = new List<CheckBoxModel>();
            if (searchViewModel.CheckBoxItems.Count == 0 || searchViewModel.CheckBoxItems == null)
            {
                foreach (Ingredient ingredient in _ingredientService.GetAllIngredients())
                {
                    ChkItem.Add(new CheckBoxModel { Id = ingredient.IngredientId, LabelName = ingredient.Name, IsChecked = false });
                }
                searchViewModel.CheckBoxItems = ChkItem;
            }
            searchViewModel.pizzas = _pizzaService.SearchPizzas(searchViewModel);

            return View(searchViewModel);
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult Delete(int id)
        {
            Pizza pizza = _pizzaService.GetById(id);
            return pizza == null ? NotFound() : View(pizza);
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var pizza = _pizzaService.GetById(id);
            if (pizza is null)
            {
                return NotFound();
            }

            _pizzaService.DeleteById(id);
            return RedirectToAction("DeleteSuccess");
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult DeleteSuccess()
        {
            return View();
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult Create()
        {
            PizzaCreateViewModel model = _pizzaService.PrepareCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult Create(PizzaCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _pizzaService.Add(model);
                return RedirectToAction("CreateSuccess");
            }
            return View(model);
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult CreateSuccess()
        {
            return View();
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult Edit(int id)
        {
            Pizza pizza = _pizzaService.GetById(id);
            return pizza is not null ? View(_pizzaService.PrepareEditViewModel(pizza)) : NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult Edit(PizzaEditViewModel pizzaEditViewModel)
        {
            if (ModelState.IsValid)
            {
                _pizzaService.Update(pizzaEditViewModel);
                return RedirectToAction("EditSuccess");
            }
            return View(pizzaEditViewModel);
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult EditSuccess()
        {
            return View();
        }

        public IActionResult ResetSearch()
        {
            PizzaSearchViewModel searchViewModel = new PizzaSearchViewModel();
            return RedirectToAction("Index", searchViewModel);
        }
    }
}
