using PocketApi.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PocketApi
{
    public class GetPocketItems
    {
        private static Uri _getUri = new Uri($"https://getpocket.com/v3/get");

        public static async Task<string> ExecuteAsync(string consumerKey, AccessToken accessToken)
        {
            return await ApiPost.ExecuteAsync(
                _getUri,
                new GetPocketItemsBody()
                {
                    ConsumerKey = consumerKey,
                    AccessToken = accessToken.Token,
                    DetailType = "complete"
                });
        }
    }
}
