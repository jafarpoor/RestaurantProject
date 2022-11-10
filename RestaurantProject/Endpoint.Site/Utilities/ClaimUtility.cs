using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Site.Utilities
{
    public static class ClaimUtility
    {
      public static  string basketCookieName = "BasketId";
        public static string GetUserId(ClaimsPrincipal cliamPrincipal)
        {
            var userCliamPrincipal = cliamPrincipal.Identity as ClaimsIdentity;
            var userId = userCliamPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }
    }
}
