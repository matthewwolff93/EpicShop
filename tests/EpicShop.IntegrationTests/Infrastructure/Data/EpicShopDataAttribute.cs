using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace EpicShop.IntegrationTests.Infrastructure.Data
{
    public class EpicShopDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            throw new NotImplementedException();
        }
    }
}
