using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketApi.UwpUnitTest
{
    [TestClass]
    public class GetPocketItemsTest
    {
        [TestMethod]
        public async Task ExecuteTestAsync()
        {
            List<PocketItem> pocketItems = await GetPocketItems.ExecuteAsync(Secrets.PocketAPIConsumerKey,
                Secrets.AccessToken);

            Assert.IsNotNull(pocketItems);
            Assert.AreNotEqual(0, pocketItems.Count);
            Assert.AreNotEqual(0, pocketItems[0].Authors.Count);
            Assert.IsNotNull(pocketItems[1].Image);
            Assert.IsNotNull(pocketItems[1].Image.ItemId);
            Assert.AreNotEqual(0, pocketItems[1].Image.Source.Length);
            Assert.IsNotNull(pocketItems[1].Images);
            Assert.AreNotEqual(0, pocketItems[1].Images.Count);
        }

        [TestMethod]
        public async Task ExecuteNoItemsTestAsync()
        {
            List<PocketItem> pocketItems = await GetPocketItems.ExecuteAsync(
                Secrets.PocketAPIConsumerKey,
                Secrets.AccessToken,
                DateTime.Now.ToUniversalTime());

            Assert.IsNotNull(pocketItems);
            Assert.AreEqual(0, pocketItems.Count);
        }
    }
}
