using PocketApi.Models;
using PocketApi.RestApiRequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocketApi
{
    public partial class PocketClient
    {
        private static Uri _obtainAccessTokenUri = new Uri($"https://getpocket.com/v3/oauth/authorize");

        public async Task<AccessToken> ObtainAccessTokenAsync(RequestToken RequestToken, string ConsumerKey)
        {
            string response = await ApiPostAsync(
                  _obtainAccessTokenUri,
                   new ObtainAccessTokenBody()
                   {
                       ConsumerKey = ConsumerKey,
                       RequestTokenCode = RequestToken.Code
                   }
               );
            AccessToken token = JsonSerializer.Deserialize<AccessToken>(response);
            token.ApiKey = ConsumerKey;

            this._accessToken = token;
            return token;
        }
    }
}
