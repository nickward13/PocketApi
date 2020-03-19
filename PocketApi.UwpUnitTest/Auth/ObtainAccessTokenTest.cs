using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocketApi.Auth;

namespace PocketApi.UwpUnitTest.Auth
{
    [TestClass]
    public class ObtainAccessTokenTest
    {
        [TestMethod]
        public async Task ExecuteAsync()
        {

            AccessToken accessToken = await ObtainAccessToken.ExecuteAsync(
                new RequestToken()
                {
                    Code = Secrets.RequestTokenCode
                },
                Secrets.PocketAPIConsumerKey);
            
            Assert.IsNotNull(accessToken);
        }
        
    }
}
