using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneClimaTempo.Models
{
    public class TemperatureRegistry
    {

        private DateTime date;

        public TemperatureRegistry(DateTime date, int temperature)
        {
            this.date = date;
            Temperature = temperature;
        }

        public string Date
        {
            get
            {
                return this.date.ToString("yyyy-MM-dd HH-mm-ss");
            }
            private set { Date = value; }
        }


        public int Temperature { get; private set; }
    }
}