using LinqKit;
using PizzaStore.Data;
using PizzaStore.Models;

namespace PizzaStore.Services
{
    public class IngredientService : IIngredientService
    {
        private ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public IngredientService(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.ToList();
        }

        public Ingredient GetById(int id)
        {
            return _context.Ingredients.SingleOrDefault(x => x.IngredientId == id);
        }

        public void Add(IngredientCreateViewModel ingredientCreateViewModel)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Name = ingredientCreateViewModel.Name;
            ingredient.Description = ingredientCreateViewModel.Description;
            string uniqueFileName = GetUniqueFileName(ingredientCreateViewModel.ImageUrl.FileName);
            string imagesPath = Path.Combine(_hostingEnvironment.WebRootPath, "img/ingr");
            string filePath = Path.Combine(imagesPath, uniqueFileName);
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            ingredientCreateViewModel.ImageUrl.CopyTo(fileStream);

            ingredient.ImageUrl = uniqueFileName;

            _context.Add(ingredient);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Ingredient ingredient = GetById(id);
            _context.Remove(ingredient);
            _context.SaveChanges();
        }

        public void Update(IngredientEditViewModel ingredientEditViewModel)
        {
            Ingredient ingredientUpdate = GetById(ingredientEditViewModel.Id);
            ingredientUpdate.Name = ingredientEditViewModel.Name;
            ingredientUpdate.Description = ingredientEditViewModel.Description;

            if(ingredientEditViewModel.ImageUrl != null)
            {
                string uniqueFileName = GetUniqueFileName(ingredientEditViewModel.ImageUrl.FileName);
                string imagesPath = Path.Combine(_hostingEnvironment.WebRootPath, "img/ingr");
                string filePath = Path.Combine(imagesPath, uniqueFileName);
                using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                ingredientEditViewModel.ImageUrl.CopyTo(fileStream);
                ingredientUpdate.ImageUrl = uniqueFileName;
            }
            _context.Update(ingredientUpdate);
            _context.SaveChanges();
        }

        public IEnumerable<Ingredient> SearchIngredients(string Name)
        {
            var predicate = PredicateBuilder.New<Ingredient>(true);

            if (!string.IsNullOrEmpty(Name))
            {
                predicate = predicate.And(x => x.Name.Contains(Name));
            }
            return _context.Ingredients.AsExpandable().Where(predicate);
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
