using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;

namespace PocketApi.UwpUnitTest.Auth
{
    [TestClass]
    public class ObtainRequestTokenTest
    {
        private PocketClient _pocketClient = new PocketClient();

        [TestMethod]
        public async Task ExecuteTest()
        {
            RequestToken requestToken = await _pocketClient.ObtainRequestTokenAsync(
                WebAuthenticationBroker.GetCurrentApplicationCallbackUri(),
                Secrets.PocketAPIConsumerKey);

            Assert.IsNotNull(requestToken);
            Assert.IsNotNull(requestToken.Code);
            Assert.AreEqual(30, requestToken.Code.Length);
        }
    }
}
