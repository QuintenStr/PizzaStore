using Microsoft.AspNetCore.Authorization;

namespace PizzaStore.Models
{
    public class MinRankHandler : AuthorizationHandler<MinRankRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinRankRequirement requirement)
        {
            if (context.User.HasClaim(x => x.Type == "RankId" && int.Parse(x.Value) >= requirement.MinRank))
            {
                    context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}