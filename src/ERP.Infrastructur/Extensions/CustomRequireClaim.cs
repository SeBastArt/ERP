using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.AuthorizationRequirements
{
    public class CustomRequireClaim : IAuthorizationRequirement
    {
        /// <summary>
        /// ClaimType
        /// </summary>
        public string ClaimType { get; }

        /// <summary>
        /// CustomRequireClaim
        /// </summary>
        /// <param name="claimType"></param>
        public CustomRequireClaim(string claimType)
        {
            ClaimType = claimType;
        }
    }

    /// <summary>
    /// CustomRequireClaimHandler
    /// </summary>
    public class CustomRequireClaimHandler : AuthorizationHandler<CustomRequireClaim>
    {
        /// <summary>
        /// HandleRequirementAsync
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequireClaim requirement)
        {
            if (context.User.Claims.Any(x => x.Type == requirement.ClaimType))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
