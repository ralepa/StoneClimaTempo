using StoneClimaTempo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoneClimaTempo.Models;
using TemperaturesLoader.Consumers.Interfaces;
using TemperaturesLoader.Consumers;

namespace StoneClimaTempo.Services
{
    public class CityService : ICityService
    {
        private ICityConsumer consumer;

        public CityService()
        {
            consumer = new CityConsumer();
        }
        
        public void ClearTemperaturesFromCity(string cityName)
        {
            throw new NotImplementedException();
        }

        public List<CityTemperatures> LoadHottestCities(List<CityTemperatures> cities)
        {
            throw new NotImplementedException();
        }

        public void PopulateCityWithTemperatures(CityTemperatures city)
        {
            throw new NotImplementedException();
        }
    }
}