using PocketApi.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PocketApi
{
    public class GetPocketItems
    {
        private static Uri _getUri = new Uri($"https://getpocket.com/v3/get");

        public static async Task<List<PocketItem>> ExecuteAsync(string consumerKey, AccessToken accessToken)
        {
            string apiResponse = await ApiPost.ExecuteAsync(
                _getUri,
                new GetPocketItemsBody()
                {
                    ConsumerKey = consumerKey,
                    AccessToken = accessToken.Token,
                    DetailType = "complete"
                });

            List<PocketItem> pocketItems = ConvertApiResponseToPocketItem(apiResponse);

            return pocketItems;
        }

        private static List<PocketItem> ConvertApiResponseToPocketItem(string apiResponse)
        {
            List<PocketItem> pocketItems = new List<PocketItem>();

            JsonDocument jsonDocument = JsonDocument.Parse(apiResponse);
            
            foreach(var itemObject in jsonDocument.RootElement.GetProperty("list").EnumerateObject())
            {
                var itemJsonDocument = JsonDocument.Parse(itemObject.Value.ToString());

                pocketItems.Add(JsonSerializer.Deserialize<PocketItem>(itemJsonDocument.RootElement.ToString()));
            }

            return pocketItems;
        }
    }
}
