using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PizzaStore.Models
{
    public class IngredientCreateViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please fill in an ingredient name.")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please fill in an ingredient description.")]
        public string? Description { get; set; }

        [Display(Name = "Cover Image")]
        [Required(ErrorMessage = "Cover Image is a required field.")]
        [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png", }, ErrorMessage = "Only image files with extensions .jpg, .jpeg and .png are allowed.")]
        public IFormFile? ImageUrl { get; set; }

    }
}
