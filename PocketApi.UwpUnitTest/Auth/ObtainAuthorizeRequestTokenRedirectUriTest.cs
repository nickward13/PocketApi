using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocketApi.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;

namespace PocketApi.UwpUnitTest
{
    [TestClass]
    public class ObtainAuthorizeRequestTokenRedirectUriTest
    {
        [TestMethod]
        public async Task ExecuteTestAsync()
        {
            Uri callbackUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
            RequestToken requestToken = await ObtainRequestToken.ExecuteAsync(callbackUri, Secrets.PocketAPIConsumerKey);
            Uri uri = ObtainAuthorizeRequestTokenRedirectUri.Execute(requestToken, callbackUri);

            Assert.IsNotNull(uri);
            Assert.IsNotNull(uri.ToString());
        }
    }
}
