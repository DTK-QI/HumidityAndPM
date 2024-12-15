using HumidityAndPM.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HumidityAndPM.Function
{
    public class CallHumidityAndPMData
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<List<CountryHourlyValueModel>?> GetCallHumidityAndPM(int limit)
        {
            try
            {
                string apiUrl = "https://data.moenv.gov.tw/api/v2/aqx_p_133?offset=0&limit=10&api_key=";
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<CountryHourlyValueModel>? result = JsonSerializer.Deserialize<List<CountryHourlyValueModel>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
    }
}
