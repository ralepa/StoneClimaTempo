using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneClimaTempo.DTOs
{
    public class Forecast
    {
        public string Date { get; set; }
        public string Weekday { get; set; }
        public string Max { get; set; }
        public string Min { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
    }
}