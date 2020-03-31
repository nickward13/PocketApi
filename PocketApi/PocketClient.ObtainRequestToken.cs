using PocketApi.Models;
using PocketApi.RestApiRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocketApi
{
    public partial class PocketClient
    {
        private static Uri _obtainRequestTokenUri = new Uri($"https://getpocket.com/v3/oauth/request");

        public async Task<RequestToken> ObtainRequestTokenAsync(Uri CallBackUri)
        {
            string response = await ApiPostAsync(
               _obtainRequestTokenUri,
                new ObtainRequestTokenBody()
                {
                    ConsumerKey = _consumerKey,
                    RedirectUri = CallBackUri.ToString()
                }
            );
            RequestToken token = JsonSerializer.Deserialize<RequestToken>(response);
            return token;
        }
    }
}
