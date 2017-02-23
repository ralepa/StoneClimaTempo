using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneClimaTempo.Models
{
    public class TemperatureRegistry
    {

        public TemperatureRegistry(DateTime date, double temperature)
        {
            Date = date;
            Temperature = temperature;
        }

        public DateTime Date { get; private set; }

        public double Temperature { get; private set; }
    }
}