using WebApiWeatherBot.Models;
using Newtonsoft.Json;

namespace WebApiWeatherBot.Clients
{
    public class WeatherClient
    {
        private HttpClient _httpClient;
        private static string _address;
        private static string _apikey;

        public WeatherClient()
        {
            _address = Constants.address;
            _apikey = Constants.apikey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_address);

        }
        public async Task<CityWeather> GetCityWeatherAsync(string query)
        {
            var responce = await _httpClient.GetAsync($"/data/2.5/weather?q={query}&appid={_apikey}");
            responce.EnsureSuccessStatusCode();
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<CityWeather>(content);
            result.Main.Temp = result.Main.Temp - 273;
            
            return result;

        }

    }
}
