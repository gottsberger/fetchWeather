using geoloc_util.GeoCodingAPI.GeoCodingAPIModels;
using geoloc_util.Utilities;
using RestSharp;

namespace geoloc_util.GeoCodingAPI
{
    internal class GeoCodingAPIHelper
    {
        public async Task<LocationResponse> GetLocationByCityState(string token, string city, string state, string country = "US")
        {
            string cityQuery = $"direct?q={city},{state},{country}&appID=" + EnvironmentManager.AuthKey;
            RestClient restClient = new RestClient(EnvironmentManager.WeatherAPIBaseUrl);
            RestRequest request = new RestRequest(cityQuery);

            var response = await restClient.GetAsync<List<LocationResponse>>(request);

            return response.FirstOrDefault();
        }

        public async Task<LocationResponse> GetLocationByZipAsync(string token, string zipCode, string country = "US")
        {
            string zipQuery = $"zip?zip={zipCode},{country}&appID=" + EnvironmentManager.AuthKey;
            RestClient restClient = new RestClient(EnvironmentManager.WeatherAPIBaseUrl);
            RestRequest request = new RestRequest(zipQuery);

            var response = await restClient.GetAsync<LocationResponse>(request);

            return response;
        }
    }
}
