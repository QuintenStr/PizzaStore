using PizzaStore.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PizzaStore.Models
{
    public class DeliveryOrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please fill in your first name.")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please fill in your last name.")]
        public string? LastName { get; set; }

        [Display(Name = "Street")]
        [Required(ErrorMessage = "Please fill in your street.")]
        public string Street { get; set; }

        [Display(Name = "House number")]
        [Required(ErrorMessage = "Please fill in your house number.")]
        public string Number { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Please fill in your zip code.")]
        public string Zip { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please fill in your city.")]
        public string City { get; set; }

        public DeliveryStatus Status { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}
