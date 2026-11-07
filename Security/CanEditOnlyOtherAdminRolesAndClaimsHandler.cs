
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace EmployeeManagement.Security
{
    public class CanEditOnlyOtherAdminRolesAndClaimsHandler
        : AuthorizationHandler<ManageAdminRolesAndClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ManageAdminRolesAndClaimsRequirement requirement)
        {
            HttpContext? httpContext = context.Resource switch
            {
                HttpContext http => http,
                AuthorizationFilterContext mvc => mvc.HttpContext,
                _ => null
            };

            if (httpContext == null)
                return Task.CompletedTask;

            string? loggedInAdminId = context.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            string adminIdBeingEdited = httpContext.Request
                .Query["userId"].ToString();

            if (string.IsNullOrWhiteSpace(loggedInAdminId) ||
                string.IsNullOrWhiteSpace(adminIdBeingEdited))
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole("Admin") &&
                context.User.HasClaim("Edit Role", "Edit Role") &&
                !string.Equals(
                    loggedInAdminId,
                    adminIdBeingEdited,
                    StringComparison.OrdinalIgnoreCase))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
