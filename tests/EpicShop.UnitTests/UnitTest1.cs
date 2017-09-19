using System;
using EpicShop.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EpicShop.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var builder = new DbContextOptionsBuilder<EpicShopContext>();
            builder.UseSqlServer(@"Data Source=localhost;Integrated Security=SSPI;Initial Catalog=EpicShop");

            var context = new EpicShopContext(builder.Options);

            //TestForShop(context);
        }
    }
}
