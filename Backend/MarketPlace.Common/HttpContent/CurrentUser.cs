using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Common.HttpContent
{
    public static class CurrentUser
    {
        private static IHttpContextAccessor _context;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor;
        }

        public static Microsoft.AspNetCore.Http.HttpContext Current => _context.HttpContext;

        public static string Username()
        {
            if (_context.HttpContext.User.Identity != null && _context.HttpContext.User.Identity.IsAuthenticated)
            {
                var identity = _context.HttpContext.User;

                return identity.Claims?.Where(c => c.Type == ClaimTypes.GivenName)
                    .Select(c => c.Value)?.SingleOrDefault() ?? "";
            }

            return "";
        }

        public static int UserId()
        {
            if (_context?.HttpContext?.User?.Identity != null && _context.HttpContext.User.Identity.IsAuthenticated)
            {
                var identity = _context.HttpContext.User;

                var userId = identity.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                    .Select(c => c.Value).SingleOrDefault();
                return int.Parse(userId ?? "1");
            }

            return 0;
        }


        public static string GetCulture()
        {
            if (_context?.HttpContext?.User?.Identity != null && _context.HttpContext.User.Identity.IsAuthenticated)
            {
                var identity = _context.HttpContext.User;

                return identity.Claims.Where(c => c.Type == "Culture")
                    .Select(c => c.Value)?.SingleOrDefault().ToLower() ?? "";
            }

            return "";
        }

        public static string SelectedCompanyId()
        {
            if (_context?.HttpContext?.User?.Identity != null && _context.HttpContext.User.Identity.IsAuthenticated)
            {
                var identity = _context.HttpContext.User;

                return identity.Claims.Where(c => c.Type == "SelectedCompany")
                    .Select(c => c.Value)?.SingleOrDefault().ToLower() ?? "";
            }

            return "";
        }
    }
}
