using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BLL.Services.Admin
{
    public class MapService
    {
        private readonly string clientId;
        private readonly string primaryKey;

        public MapService(string clientId, string primaryKey)
        {
            this.clientId = clientId;
            this.primaryKey = primaryKey;
        }

        public async Task<double> CalculateDistance(string origin, string destination)
        {
            string apiUrl = $"https://atlas.microsoft.com/route/directions/json?api-version=1.0&query={origin}:{destination}&subscription-key={primaryKey}&api-version=1.0&travelMode=driving";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-ms-client-id", clientId);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var distance = ParseDistance(result);
                    return distance;
                }
            }

            return -1; // Distance calculation failed
        }

        private double ParseDistance(string responseContent)
        {
            // You need to parse the JSON response here to extract the distance value.
            // Example parsing logic:
            // var jsonObject = JObject.Parse(responseContent);
            // var distance = (double)jsonObject["routes"][0]["summary"]["lengthInMeters"] / 1000;
            // return distance;

            // For demonstration purpose, let's assume the distance is 100 kilometers.
            return 100;
        }
    }
}
