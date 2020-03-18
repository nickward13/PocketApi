using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocketApi
{
    public class ObtainRequestToken
    {
        private static Uri _obtainRequestTokenUri = new Uri($"https://getpocket.com/v3/oauth/request");

        public static async Task<RequestToken> ExecuteAsync(Uri CallBackUri, string ConsumerKey)
        {
            string response = await ApiPost.ExecuteAsync(
               _obtainRequestTokenUri,
                new ObtainRequestTokenBody()
                {
                    ConsumerKey = ConsumerKey,
                    RedirectUri = CallBackUri.ToString()
                }
            );
            RequestToken token = JsonSerializer.Deserialize<RequestToken>(response);
            return token;
        }
    }
}
