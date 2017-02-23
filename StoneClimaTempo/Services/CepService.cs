using Microsoft.Practices.Unity;
using StoneClimaTempo.Cache;
using StoneClimaTempo.DTOs;
using StoneClimaTempo.Models;
using StoneClimaTempo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemperaturesLoader.Consumers;
using TemperaturesLoader.Consumers.Interfaces;

namespace StoneClimaTempo.Services
{

    class CepService:ICepService
    {
        
        private readonly ICepConsumer consumer;
        

        /// <summary>
        /// Construtor do serviço de CEP
        /// </summary>
        public CepService()
        {
            this.consumer = new CepConsumer();
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
        
        /// <summary>
        /// Carrega o nome da cidade pelo CEP
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        public string LoadCityNameByCep(string cep)
        {
            CepData data = consumer.LoadCityNameByCep(cep);
            if(data == null)
            {
                return null;
            }
            return consumer.LoadCityNameByCep(cep).Localidade;
        }
    }
}