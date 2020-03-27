using PocketApi.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocketApi
{
    public class AddPocketItem
    {
        private static Uri _addUri = new Uri($"https://getpocket.com/v3/add");

        public static async Task<PocketItem> ExecuteAsync(string consumerKey, AccessToken accessToken, Uri uri)
        {
            PocketItem addedPocketItem = new PocketItem();
            
            string apiResponse = await ApiPost.ExecuteAsync(
                _addUri,
                new AddPocketItemBody()
                {
                    ConsumerKey = consumerKey,
                    AccessToken = accessToken.Token,
                    Uri = uri
                });

            JsonDocument apiJsonDocument = JsonDocument.Parse(apiResponse);
            foreach(JsonProperty property in apiJsonDocument.RootElement.EnumerateObject())
            {
                if (property.Name == "item")
                    addedPocketItem = Converters.PocketConverter.ConvertJsonToPocketItem(property);
            }

            return addedPocketItem;
        }

    }
}
