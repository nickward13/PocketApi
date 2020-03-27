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
            List<PocketItem> pocketItems = await GetPocketItems.ExecuteAsync(Secrets.PocketAPIConsumerKey,
                Secrets.AccessToken);

            Assert.IsNotNull(pocketItems);
            Assert.AreNotEqual(0, pocketItems.Count);
            Assert.AreNotEqual(0, pocketItems[0].Authors.Count);
        }
    }
}
