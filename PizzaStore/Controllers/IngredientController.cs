using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Data;
using PizzaStore.Models;
using PizzaStore.Services;

namespace PizzaStore.Controllers
{
    public class IngredientController : Controller
    {
        private IIngredientService _ingredientService;

        public IngredientController(IPizzaService pizzaService, IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public IActionResult Index(IngredientSearchViewModel ingredientSearchViewModel)
        {
            ingredientSearchViewModel.Ingredients = _ingredientService.SearchIngredients(ingredientSearchViewModel.Name);
            return View(ingredientSearchViewModel);
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult Create()
        {
            IngredientCreateViewModel ingredientCreateViewModel = new IngredientCreateViewModel();
            return View(ingredientCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult Create(IngredientCreateViewModel ingredientCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                _ingredientService.Add(ingredientCreateViewModel);
                return RedirectToAction("CreateSuccess");
            }
            else
            {
                return View(ingredientCreateViewModel);
            }
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult Delete(int id)
        {
            Ingredient ingredient = _ingredientService.GetById(id);
            return ingredient == null ? NotFound() : View(ingredient);
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = _ingredientService.GetById(id);
            if (ingredient is null)
            {
                return NotFound();
            }

            _ingredientService.DeleteById(ingredient.IngredientId);
            return RedirectToAction("DeleteSuccess");
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult DeleteSuccess()
        {
            return View();
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult Edit(int id)
        {
            IngredientEditViewModel ingredientEditViewModel = new IngredientEditViewModel();
            Ingredient ingredient = _ingredientService.GetById(id);
            if (ingredient is null)
            {
                return NotFound();
            }
            ingredientEditViewModel.Id = ingredient.IngredientId;
            ingredientEditViewModel.Name = ingredient.Name;
            ingredientEditViewModel.Description = ingredient.Description;
            return View(ingredientEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult Edit(IngredientEditViewModel ingredientEditViewModel)
        {
            if (ModelState.IsValid)
            {
                _ingredientService.Update(ingredientEditViewModel);
                return RedirectToAction("EditSuccess");
            }
            else
            {
                return View(ingredientEditViewModel);
            }
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult EditSuccess()
        {
            return View();
        }

        [Authorize(Policy = "MinRankAdmin")]
        public IActionResult CreateSuccess()
        {
            return View();
        }

        public IActionResult ResetSearch()
        {
            IngredientSearchViewModel ingredientSearchViewModel = new IngredientSearchViewModel();
            return RedirectToAction("Index", ingredientSearchViewModel);
        }

    }
}
