using System.Security.Claims;
using EpicShop.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace EpicShop.API.Modules.User
{
    public class UserManager : IUserManager
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserManager(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string ResolveUserName()
        {
            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            return "API user";
        }
    }
}
