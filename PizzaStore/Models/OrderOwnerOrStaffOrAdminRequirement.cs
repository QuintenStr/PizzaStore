using Microsoft.AspNetCore.Authorization;

namespace PizzaStore.Models
{
    public class OrderOwnerOrStaffOrAdminRequirement : IAuthorizationRequirement { }
}