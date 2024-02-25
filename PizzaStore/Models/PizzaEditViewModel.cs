using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PizzaStore.Models
{
    public class PizzaEditViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Id is a required field.")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please fill in a pizza name.")]
        public string? Name { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please fill in a pizza price.")]
        public double Price { get; set; }

        [Display(Name = "Cover Image (to keep previous image, simply don't upload a new one)")]
        [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png", }, ErrorMessage = "Only image files with extensions .jpg, .jpeg and .png are allowed.")]
        public IFormFile? ImageUrl { get; set; }
        [MinimumOneIngredient(ErrorMessage = "Please select atleast one ingredient.")]
        public List<CheckBoxModel> CheckBoxItems { get; set; } = new List<CheckBoxModel>();
    }
}
