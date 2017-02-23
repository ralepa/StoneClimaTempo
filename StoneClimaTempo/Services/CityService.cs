using StoneClimaTempo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoneClimaTempo.Models;
using TemperaturesLoader.Consumers.Interfaces;
using TemperaturesLoader.Consumers;
using StoneClimaTempo.Cache;
using StoneClimaTempo.DTOs;

namespace StoneClimaTempo.Services
{
    public class CityService : ICityService
    {
        private ICityConsumer consumer;

        public CityService()
        {
            consumer = new CityConsumer();
        }

        /// <summary>
        /// Retorna a lista das cidades registradas
        /// </summary>
        /// <returns></returns>
        private List<CityTemperatures> GetCachedData()
        {
            DataCache cache = DataCache.Instance;
            List<CityTemperatures> cities = cache.Cities;
            return cities;
        }

        private CityTemperatures FindCityOnCitiesList(string cityName)
        {
            List<CityTemperatures> cities = GetCachedData();
            CityTemperatures city = cities.SingleOrDefault(cityItem => cityItem.City.Equals(cityName));
            return city;
        }

        /// <summary>
        /// Busca e adiciona uma cidade na lista de cidades
        /// Retorna false se a cidade não for encontrada
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public bool AddCityToProcessingList(string cityName)
        {
            List<CityTemperatures> cities = GetCachedData();

            bool alreadyRegistered = cities.Any(city => city.City.Equals(cityName));

            if (alreadyRegistered)
            {
                return false;
            }

            CityTemperatures newCity = new CityTemperatures(cityName);
            PopulateCityWithTemperatures(newCity);
            cities.Add(newCity);
            return true;
        }

        /// <summary>
        /// Limpa a lista de temperaturas de uma cidade
        /// </summary>
        /// <param name="cityName"></param>
        public void ClearTemperaturesFromCity(string cityName)
        {
            List<CityTemperatures> cities = GetCachedData();
            CityTemperatures city = cities.SingleOrDefault(cityItem => cityItem.City.Equals(cityName));
            if (city != null)
            {
                city.ResetRegistries();
            }
        }

        /// <summary>
        /// Carrega as X cidades com maiores temperaturas
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        public List<CityTemperatures> LoadHottestCities(int quantity)
        {
            List<CityTemperatures> cities = GetCachedData();

            // Faz uma busca pela maior temperatura de cada cidade registrada, somente nas cidades que contenham alguma temperatura
            IDictionary<CityTemperatures, double> result = cities
                .Where(city => city.Temperatures.Count > 0 )
                .Select(city => new { city, maxTemp = city.Temperatures.Max(temperature => temperature.Temperature) })
                .ToDictionary(t => t.city, t => t.maxTemp);

            // Ordena decrescentemente pelas temperaturas e pega os top 3 da lista
            return result.OrderByDescending(item => item.Value).Take(quantity).Select(entry => entry.Key).ToList();
                       
        }

        /// <summary>
        /// Processa lista de temperaturas no registro da cidade
        /// Caso já tenha estourado o limite de 30 (1 por hora, 30 no total = 30 horas) remove a mais antiga para inserir a nova
        /// </summary>
        /// <param name="city"></param>
        public void PopulateCityWithTemperatures(CityTemperatures city)
        {
            string cityName = city.City;
            TemperaturesData data = consumer.LoadTemperaturesData(cityName);
            Results resultFromApi = data.Results;

            DateTime dateTime = BuildDateTimeFromApiResults(resultFromApi);
            int temp = resultFromApi.Temp;

            TemperatureRegistry registry = new TemperatureRegistry(dateTime, (double)temp);

            CleanOldRegistriesFromCity(city);

            city.Temperatures.Add(registry);

        }

        /// <summary>
        /// Mantém a lista com o máximo de X itens
        /// </summary>
        /// <param name="city"></param>
        private void CleanOldRegistriesFromCity(CityTemperatures city)
        {
            List<TemperatureRegistry> oldRegistries = city.Temperatures;
            int maxRegistries = Int32.Parse(Resource.MaxRegistries);

            int diff = oldRegistries.Count - maxRegistries;

            if (diff >= 0)
            {
                // Pela lógica, se a quantidade for 0 do diff, eu tenho que remover pelo menos 1 elemento, então a conta é sempre +1 do diff
                int removeQuantity = diff + 1;
                List<TemperatureRegistry> itemsToRemove = oldRegistries.OrderByDescending(registry => registry.Date).Take(removeQuantity).ToList();
                oldRegistries.RemoveAll(registry => itemsToRemove.Contains(registry));
            }
        }

        /// <summary>
        /// Por padrão a API retorna o formato da data dd/MM/yyyy e a hora no formato hh:mm
        /// Esse método parseia essas strings e monta as datas
        /// </summary>
        /// <param name="apiResults"></param>
        /// <returns></returns>
        private DateTime BuildDateTimeFromApiResults(Results apiResults)
        {
            string dateStr = apiResults.Date;
            string timeStr = apiResults.Time;

            string[] dateSplit = dateStr.Split('/');
            string[] timeSplit = timeStr.Split(':');

            int year = Int32.Parse(dateSplit[2]);
            int month = Int32.Parse(dateSplit[1]);
            int day = Int32.Parse(dateSplit[0]);

            int hour = Int32.Parse(timeSplit[0]);
            int minutes = Int32.Parse(timeSplit[1]);

            // 0 segundos
            return new DateTime(year, month, day, hour, minutes, 0);
        }

        /// <summary>
        /// Busca e remove o item da lista
        /// </summary>
        /// <param name="cityName"></param>
        public void RemoveCityToProcessingList(string cityName)
        {
            List<CityTemperatures> cities = GetCachedData();
            cities.RemoveAll(city => city.City.Equals(cityName));
        }

        /// <summary>
        /// Retorna todas as cidades registradas
        /// </summary>
        /// <returns></returns>
        public List<CityTemperatures> LoadAllCities()
        {
            List<CityTemperatures> cities = GetCachedData();
            return cities;
        }

        /// <summary>
        /// Retorna cidade e suas temperaturas pelo nome
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public CityTemperatures LoadCityByName(string cityName)
        {
            List<CityTemperatures> cities = GetCachedData();
            return cities.SingleOrDefault(city => city.City.Equals(cityName));
        }

        /// <summary>
        /// Limpa a lista de cidades do processamento
        /// Somente utilizada nos testes
        /// </summary>
        public void ClearAllCities()
        {
            List<CityTemperatures> cities = GetCachedData();
            cities.Clear();
        }

        /// <summary>
        /// Adiciona uma cidade no processamento pelo CEP
        /// Retorna false se a cidade não for encontrada
        /// </summary>
        /// <param name="cep"></param>
        public bool AddCityToProcessingListByCep(string cep)
        {
            ICepService cepService = new CepService();
            string cityName = cepService.LoadCityNameByCep(cep);

            if(cityName == null)
            {
                return false;
            }
            return AddCityToProcessingList(cityName);
        }
    }
}