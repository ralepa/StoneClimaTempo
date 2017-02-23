using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneClimaTempo.Models
{
    public class CityTemperatures
    {

        public CityTemperatures(string name)
        {
            Name = name;
            Temperatures = new List<TemperatureRegistry>();
        }

        public string City { get; set; }
        public List<TemperatureRegistry> Temperatures { get; set; }

        public string Name { get; private set; }

        
        public void AddTemperatureRegistry(DateTime dateTime, double temp)
        {
            var temperature = new TemperatureRegistry(dateTime, temp);
            Temperatures.Add(temperature);
        }

        public void ResetRegistries()
        {
            Temperatures.Clear();
        }

    }
}