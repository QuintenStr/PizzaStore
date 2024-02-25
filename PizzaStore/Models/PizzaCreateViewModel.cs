using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PizzaStore.Models
{
    public class PizzaCreateViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please fill in a pizza name.")]
        public string? Name { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please fill in a pizza price.")]
        public double Price { get; set; }

        [Display(Name = "Cover Image")]
        [Required(ErrorMessage = "Cover Image is a required field.")]
        [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png", }, ErrorMessage = "Only image files with extensions .jpg, .jpeg and .png are allowed.")]
        public IFormFile? ImageUrl { get; set; }
        [MinimumOneIngredient(ErrorMessage = "Please select atleast one ingredient.")]
        public List<CheckBoxModel> CheckBoxItems { get; set; } = new List<CheckBoxModel>();
    }
}
