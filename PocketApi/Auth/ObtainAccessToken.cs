using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocketApi.Auth
{
    public class ObtainAccessToken
    {
        private static Uri _obtainAccessTokenUri = new Uri($"https://getpocket.com/v3/oauth/authorize");

        public static async Task<AccessToken> ExecuteAsync(RequestToken RequestToken, string ConsumerKey)
        {
            string response = await ApiPost.ExecuteAsync(
                  _obtainAccessTokenUri,
                   new ObtainAccessTokenBody()
                   {
                       ConsumerKey = ConsumerKey,
                       RequestTokenCode = RequestToken.Code
                   }
               );
            AccessToken token = JsonSerializer.Deserialize<AccessToken>(response);
            return token;
        }
    }
}
