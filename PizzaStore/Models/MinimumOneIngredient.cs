using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Models
{
    public class MinimumOneIngredient : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return (value is List<CheckBoxModel> cbm) && cbm.Any(item => item.IsChecked) ? true : false;
        }
    }
}
