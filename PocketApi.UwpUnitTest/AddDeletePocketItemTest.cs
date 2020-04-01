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
    public class AddDeletePocketItemTest
    {
        PocketClient _pocketClient = new PocketClient(Secrets.AccessToken);

        [TestMethod]
        public async Task ExecuteTestAsync()
        {
            PocketItem pocketItem = await TestAddAsync();
            await TestFavoriteAsync(pocketItem);
            await TestUnFavoriteAsync(pocketItem);
            await TestArchiveAsync(pocketItem);
            await TestReAddAsync(pocketItem);
            await TestDeleteAsync(pocketItem);
        }

        private async Task<PocketItem> TestAddAsync()
        {
            PocketItem newPocketItem = await _pocketClient.AddPocketItemAsync(new Uri("https://www.theage.com.au/culture/comedy/the-at-home-comedy-festival-20200318-p54bhu.html"));
            List<PocketItem> newPocketItems = await _pocketClient.GetPocketItemsAsync(
                DateTime.Now.ToUniversalTime().Subtract(new TimeSpan(0, 0, 30)));

            Assert.IsNotNull(newPocketItem);
            Assert.IsNotNull(newPocketItem.Id);
            Assert.AreNotEqual(0, newPocketItem.Id.Length);
            Assert.AreNotEqual(0, newPocketItems.Count);
            return newPocketItem;
        }

        private async Task TestFavoriteAsync(PocketItem pocketItem)
        {
            bool result = await _pocketClient.MarkFavoritePocketItemAsync(pocketItem);
            Assert.AreEqual(true, result);
        }

        private async Task TestUnFavoriteAsync(PocketItem pocketItem)
        {
            bool result = await _pocketClient.UnFavoritePocketItemAsync(pocketItem);
            Assert.AreEqual(true, result);
        }

        private async Task TestArchiveAsync(PocketItem pocketItem)
        {
            bool result = await _pocketClient.ArchivePocketItemAsync(pocketItem);
            Assert.AreEqual(true, result);
        }

        private async Task TestReAddAsync(PocketItem pocketItem)
        {
            bool result = await _pocketClient.ReAddPocketItemAsync(pocketItem);
            Assert.AreEqual(true, result);
        }

        private async Task TestDeleteAsync(PocketItem pocketItem)
        {
            bool result = await _pocketClient.DeletePocketItemAsync(pocketItem);

            Assert.AreEqual(true, result);
        }
    }
}
