using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperaturesLoader.Consumers.Interfaces;

namespace TemperaturesLoader.Consumers
{
    public class CityConsumer : ICityConsumer
    {
        public string LoadCityNameByCep(string cep)
        {
            throw new NotImplementedException();
        }

        public object LoadTemperaturesData(string cityName)
        {
            throw new NotImplementedException();
        }
    }
}
