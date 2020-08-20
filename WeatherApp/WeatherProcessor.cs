using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace WeatherApp
{
    public class WeatherProcessor
    {
        public static async Task<WeatherModel> LoadWeatherInfo()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=detroit&APPID=21669d5e682f670049fa3bbe7834825f";



            using (System.Net.Http.HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    WeatherOuterModel result = await response.Content.ReadAsAsync<WeatherOuterModel>();


                    return result.Coord;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
