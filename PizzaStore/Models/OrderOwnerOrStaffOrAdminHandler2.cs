using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using PizzaStore.Data;

namespace PizzaStore.Models
{
    public class OrderOwnerOrStaffOrAdminHandler2 : AuthorizationHandler<OrderOwnerOrStaffOrAdminRequirement2, DeliveryOrder>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public OrderOwnerOrStaffOrAdminHandler2(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OrderOwnerOrStaffOrAdminRequirement2 requirement, DeliveryOrder resource)
        {
            var user = await _userManager.GetUserAsync(context.User);
            if (user == null)
            {
                return;
            }
            if (resource.UserId == user.Id)
            {
                context.Succeed(requirement);
            }
            if (context.User.HasClaim(x => x.Type == "RankId" && int.Parse(x.Value) >= 2))
            {
                context.Succeed(requirement);
            }
        }
    }
}
