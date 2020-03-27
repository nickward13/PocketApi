using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketApi.UwpUnitTest
{
    [TestClass]
    public class AddDeletePocketItemTest
    {
        [TestMethod]
        public async Task ExecuteTestAsync()
        {
            PocketItem newPocketItem = await AddPocketItem.ExecuteAsync(Secrets.PocketAPIConsumerKey, Secrets.AccessToken, new Uri("https://www.theage.com.au/culture/comedy/the-at-home-comedy-festival-20200318-p54bhu.html"));
            List<PocketItem> newPocketItems = await GetPocketItems.ExecuteAsync(
                Secrets.PocketAPIConsumerKey, 
                Secrets.AccessToken, 
                DateTime.Now.ToUniversalTime().Subtract(new TimeSpan(0, 0, 30)));

            Assert.IsNotNull(newPocketItem);
            Assert.IsNotNull(newPocketItem.Id);
            Assert.AreNotEqual(0, newPocketItem.Id.Length);
            Assert.AreNotEqual(0, newPocketItems.Count);

            bool result = await DeletePocketItem.ExecuteAsync(
                Secrets.PocketAPIConsumerKey,
                Secrets.AccessToken,
                newPocketItem);

            Assert.AreEqual(true, result);
        }
    }
}
