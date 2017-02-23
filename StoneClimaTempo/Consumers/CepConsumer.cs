using Newtonsoft.Json;
using StoneClimaTempo;
using StoneClimaTempo.DTOs;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TemperaturesLoader.Consumers.Interfaces;

namespace TemperaturesLoader.Consumers
{
    public class CepConsumer : ICepConsumer
    {
        public CepData LoadCityNameByCep(string cep)
        {
            var task = Task.Run(async () => {

                return await LoadCityNameFromApi(cep);
            });
            var cepData = task.Result;
            return JsonConvert.DeserializeObject<CepData>(cepData);
        }

        private async Task<string> LoadCityNameFromApi(string cep)
        {
            using (var client = new HttpClient())
            {
                string address = Resource.ApiCepUrl;
                
                string URL = String.Format(address, cep);

                var response =
                    await client.GetStringAsync(URL);
                return response;
            }
        }
    }
}
