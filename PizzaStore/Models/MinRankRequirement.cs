using Microsoft.AspNetCore.Authorization;

namespace PizzaStore.Models
{
    public class MinRankRequirement : IAuthorizationRequirement
    {
        public MinRankRequirement(int minRank)
        {
            MinRank = minRank;
        }
        public int MinRank { get; }
    }
}
