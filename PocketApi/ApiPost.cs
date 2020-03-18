﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocketApi
{
    internal class ApiPost
    {
        internal static async Task<string> ExecuteAsync(Uri requestUri, object body)
        {
            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Accept", "application/json");
                string jsonBody = JsonSerializer.Serialize(body);
                StringContent content = new StringContent(
                    jsonBody,
                    UTF8Encoding.UTF8,
                    "application/json");
                HttpResponseMessage response = await client.PostAsync(requestUri, content);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
        }
        public string Execute()
        {
            return "hello";
        }
    }
}