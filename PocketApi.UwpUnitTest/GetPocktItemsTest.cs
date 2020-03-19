using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketApi.UwpUnitTest
{
    [TestClass]
    public class GetPocktItemsTest
    {
        [TestMethod]
        public async Task ExecuteTestAsync()
        {
            string response = await GetPocketItems.ExecuteAsync(Secrets.PocketAPIConsumerKey,
                Secrets.AccessToken);

            Assert.IsNotNull(response);
        }
    }
}
