using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Evently.Common.Application.Exceptions;

namespace Evently.Common.Infrastructure.Authentication;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
       string? userId  = claimsPrincipal?.FindFirst(CustomClaims.Sub)?.Value;
        return Guid.TryParse(userId, out Guid parsedUserId) ? parsedUserId.ToString() : throw new EventlyException("User identifier is unavailable");
    }
    public static string GetIdentityId(this ClaimsPrincipal claimsPrincipal)
    {
        string? identityId = claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return identityId ?? throw new EventlyException("User identity is unavailable");
    }
    public static HashSet<string> GetPermissions(this ClaimsPrincipal claimsPrincipal)
    {
       IEnumerable<Claim> permissions = claimsPrincipal?.FindAll(CustomClaims.Permission) ?? throw new EventlyException("Permissions are unavailable");
        return permissions.Select(permission => permission.Value).ToHashSet();
    }
}
