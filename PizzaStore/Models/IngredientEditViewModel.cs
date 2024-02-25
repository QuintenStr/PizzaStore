using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PizzaStore.Models
{
    public class IngredientEditViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Id is a required field.")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please fill in an ingredient name.")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please fill in an ingredient description.")]
        public string? Description { get; set; }

        [Display(Name = "Cover Image (to keep previous image, simply don't upload a new one)")]
        [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png", }, ErrorMessage = "Only image files with extensions .jpg, .jpeg and .png are allowed.")]
        public IFormFile? ImageUrl { get; set; }
    }
}
