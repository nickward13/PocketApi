using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocketApi
{
    public partial class PocketClient
    {
        private HttpClient _httpClient = new HttpClient();

        internal async Task<string> ApiPostAsync(Uri requestUri, object body)
        {
            if(!_httpClient.DefaultRequestHeaders.Contains("X-Accept"))
                _httpClient.DefaultRequestHeaders.Add("X-Accept", "application/json");
            
            string jsonBody = JsonSerializer.Serialize(body);
            StringContent content = new StringContent(
                jsonBody,
                UTF8Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}
