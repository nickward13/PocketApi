using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using PocketApi.Models;
using PocketApi.RestApiRequestModels;
using System.Runtime.CompilerServices;

namespace PocketApi
{
    public partial class PocketClient
    {
        private static Uri _getUri = new Uri($"https://getpocket.com/v3/get");

        public async Task<List<PocketItem>> GetPocketItemsAsync(DateTime lastSyncDateTime)
        {
            double lastSyncUnixTimestamp = Converters.UnixTimestampConverter.ToUnixtimestamp(lastSyncDateTime);

            string apiResponse = await ApiPostAsync(
                _getUri,
                new GetPocketItemsBody()
                {
                    ConsumerKey = this._accessToken.ApiKey,
                    AccessToken = this._accessToken.Token,
                    DetailType = "complete",
                    Since = lastSyncUnixTimestamp,
                    State = PocketItemState.All,
                    Sort = PocketItemSort.Oldest
                });

            List<PocketItem> pocketItems = ConvertJsonToPocketItems(apiResponse);

            return pocketItems;
        }

        public async Task<List<PocketItem>> GetPocketItemsAsync()
        {
            List<PocketItem> pocketItems = await this.GetPocketItemsAsync(new DateTime(1970, 1, 1));
            return pocketItems;
        }

        private List<PocketItem> ConvertJsonToPocketItems(string json)
        {
            List<PocketItem> pocketItems = new List<PocketItem>();

            JsonDocument apiJsonDocument = JsonDocument.Parse(json);

            JsonElement jsonElement;
            string statusString = "";

            if (apiJsonDocument.RootElement.TryGetProperty("status", out jsonElement))
                statusString = jsonElement.ToString();

            if (statusString == "1")
            {
                foreach (JsonProperty pocketItemJsonProperty in apiJsonDocument.RootElement.GetProperty("list").EnumerateObject())
                {
                    PocketItem pocketItem = Converters.PocketConverter.ConvertJsonToPocketItem(pocketItemJsonProperty);

                    pocketItems.Add(pocketItem);
                }
            }

            return pocketItems;
        }
    }
}
