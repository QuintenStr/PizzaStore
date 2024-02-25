using PizzaStore.Data;
using PizzaStore.Models;

namespace PizzaStore.Services
{
    public interface IIngredientService
    {
        public IEnumerable<Ingredient> GetAllIngredients();
        public Ingredient GetById(int id);
        public void Add(IngredientCreateViewModel ingredientCreateViewModel);
        public void DeleteById(int id);
        public void Update(IngredientEditViewModel ingredientEditViewModel);
        public IEnumerable<Ingredient> SearchIngredients(string Name);
    }
}
