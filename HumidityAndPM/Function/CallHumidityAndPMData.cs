using HumidityAndPM.Models;
using HumidityAndPMDataConnect.Models;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HumidityAndPM.Function
{
    public class CallHumidityAndPMData
    {
        private readonly string apiKey;
        private readonly WeatherContext SQLContext;
        public CallHumidityAndPMData()
        {
            apiKey = Environment.GetEnvironmentVariable("API_moenv") ?? throw new ArgumentNullException("API_moenv is null");
            SQLContext = new WeatherContext();
        }
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<List<CountryHourlyValueModel>> GetCallHumidityAndPM(int limit)
        {
            try
            {
                string apiUrl = $"https://data.moenv.gov.tw/api/v2/aqx_p_133?language=zh&limit={limit}&api_key={apiKey}";
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                CountryHourlyViewModel? result = JsonSerializer.Deserialize<CountryHourlyViewModel>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var values = result.records.Where(x => x.siteid == "84").ToList();
                
                //只取最新的時間資料
                var time = values[0].monitordate;
                values = values.Where(x => x.monitordate == time).ToList();


                return values;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
    
        public string SaveHumidityAndPMData()
        {
            var result = GetCallHumidityAndPM(200).Result;
            if(result[0].monitordate == null)
            {
                return "No data";
            }
            var ResultTime = DateTime.Parse(result[0].monitordate);
            var SQLValue = SQLContext.WeatherValues.Where(x => x.RecordTime == ResultTime).ToList();
            if (SQLValue.Count == 0)
            {
                foreach (var item in result)
                {
                    if(item.concentration == "x")
                    {
                        continue;
                    }
                    var value = float.Parse(item.concentration);

                    WeatherValue weatherValue = new WeatherValue
                    {
                        CountryId = item.siteid,
                        ValueId = item.itemid,
                        ValueName = item.itemname,
                        Value = value,
                        RecordTime = ResultTime
                    };
                    SQLContext.WeatherValues.Add(weatherValue);
                    SQLContext.SaveChanges();
                }
            }
            return "ok";
        }
    }
}
