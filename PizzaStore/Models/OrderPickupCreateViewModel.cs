using PizzaStore.Data;
using PizzaStore.Services;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PizzaStore.Models
{
    public class OrderPickupCreateViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please fill in your first name.")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please fill in your last name.")]
        public string? LastName { get; set; }

        [Display(Name = "Pickup Time")]
        [Required(ErrorMessage = "Please choose a pickup time.")]
        [DataType(DataType.Time)]
        public TimeSpan PickupTime { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
    }
}
