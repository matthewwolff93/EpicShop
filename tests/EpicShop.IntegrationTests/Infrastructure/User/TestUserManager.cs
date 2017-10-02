using EpicShop.Core.Infrastructure.Services;

namespace EpicShop.IntegrationTests.Infrastructure.User
{
    public class TestUserManager : IUserManager
    {
        public string ResolveUserName()
        {
            return "Unit test user";
        }
    }
}
