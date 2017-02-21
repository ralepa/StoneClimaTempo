using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneClimaTempo.Models
{
    public class City
    {

        public City(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public IDictionary<DateTime, double> Temperatures { get; private set; }


        public void AddTemperatureRegistry(DateTime dateTime, double temp)
        {
            Temperatures.Add(dateTime, temp);
        }

        public void ResetRegistries()
        {
            Temperatures.Clear();
        }

    }
}