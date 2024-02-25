using PizzaStore.Data;
using PizzaStore.Models;

namespace PizzaStore.Services
{
    public interface IPizzaService
    {
        public IEnumerable<Pizza> GetAllPizzas();
        public PizzaCreateViewModel PrepareCreateViewModel();
        public IEnumerable<Pizza> SearchPizzas(PizzaSearchViewModel searchViewModel);
        public Pizza GetById(int id);
        public void DeleteById(int id);
        public void Add(PizzaCreateViewModel model);
        public PizzaEditViewModel PrepareEditViewModel(Pizza pizza);
        public void Update(PizzaEditViewModel pizzaEditViewModel);
    }
}
