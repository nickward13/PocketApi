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
    public class ObtainAuthorizeRequestTokenRedirectUriTest
    {
        private PocketClient _pocketClient = new PocketClient(Secrets.PocketAPIConsumerKey);

        [TestMethod]
        public async Task ExecuteTestAsync()
        {
            Uri callbackUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
            RequestToken requestToken = await _pocketClient.ObtainRequestTokenAsync(callbackUri);
            Uri uri = _pocketClient.ObtainAuthorizeRequestTokenRedirectUri(requestToken, callbackUri);

            Assert.IsNotNull(uri);
            Assert.IsNotNull(uri.ToString());
        }
    }
}
