using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WidenApiClient
{
    class Program
    {
        private class AssetWithEmbedsResponse
        {
            public Dictionary<string, AssetEmbed> embeds { get; set; }
        }

        private class AssetEmbed
        {
            public string url { get; set; }
            public string html { get; set; }
        }

        static void Main(string[] args)
        {
            PerformGet().Wait();
        }

        static async Task PerformGet()
        {
            var authToken = "Bearer molcikas/338e438a5748bf860511741cb3fe3402";
            var assetId = "58891697-4db0-4c8c-a02b-722a9fd6df16";

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.widencollective.com");
            client.DefaultRequestHeaders.Add("Authorization", authToken);

            HttpResponseMessage response = await client.GetAsync(string.Format("v2/assets/{0}?expand=embeds", assetId));
            var assetWithEmbedsResponse = await response.Content.ReadAsAsync<AssetWithEmbedsResponse>();
        }
    }
}
