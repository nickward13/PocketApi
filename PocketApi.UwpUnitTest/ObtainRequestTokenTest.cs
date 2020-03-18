using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;

namespace PocketApi.UwpUnitTest
{
    [TestClass]
    public class ObtainRequestTokenTest
    {
        [TestMethod]
        public async Task ExecuteTest()
        {
            RequestToken requestToken = await ObtainRequestToken.ExecuteAsync(
                WebAuthenticationBroker.GetCurrentApplicationCallbackUri(),
                Secrets.PocketAPIConsumerKey);

            Assert.IsNotNull(requestToken);
            Assert.IsNotNull(requestToken.Code);
            Assert.AreEqual(30, requestToken.Code.Length);
        }
    }
}
