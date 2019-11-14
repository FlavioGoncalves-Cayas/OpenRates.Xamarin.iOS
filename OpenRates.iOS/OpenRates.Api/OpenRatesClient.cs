using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenRates.Api
{
    public class OpenRatesClient
    {
        static OpenRatesClient _instance;

        public static OpenRatesClient Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new OpenRatesClient();

                return _instance;
            }
        }

        readonly HttpClient _httpClient;
        
        public OpenRatesClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://api.openrates.io/") };
        }

        public async Task<OpenRatesResponse> GetLatestAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("latest");

                if (!response.IsSuccessStatusCode)
                    throw new OpenRatesClientException();

                return OpenRatesResponse.FromJson(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                throw new OpenRatesClientException(e);
            }
        }

        public async Task<OpenRatesResponse> GetLatestWithBaseAsync(string @base)
        {
            try
            {
                var response = await _httpClient.GetAsync($"latest?base={@base}");

                if (!response.IsSuccessStatusCode)
                    throw new OpenRatesClientException();

                return OpenRatesResponse.FromJson(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                throw new OpenRatesClientException(e);
            }
        }
    }

}