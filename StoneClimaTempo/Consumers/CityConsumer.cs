using StoneClimaTempo;
using StoneClimaTempo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TemperaturesLoader.Consumers.Interfaces;

namespace TemperaturesLoader.Consumers
{
    public class CityConsumer : ICityConsumer
    {
        public TemperaturesData LoadTemperaturesData(string cityName)
        {
            var task = Task.Run(async () => {

                return await LoadTemperaturesFromApi(cityName);
            });
            string cityData = task.Result;

            return cityData;
        }

        private async Task<string> LoadTemperaturesFromApi(string cityName)
        {
            using (var client = new HttpClient())
            {
                string address = Resource.ApiTemperaturesUrl;
                string key = Resource.ApiTemperaturesKey;
                string URL = String.Format(address, cityName, key);

                var response =
                    await client.GetStringAsync(URL);
                return response;
            }
        }
    }
}
