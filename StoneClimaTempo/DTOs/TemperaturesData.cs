using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneClimaTempo.DTOs
{
    public class TemperaturesData
    {
        public string By { get; set; }
        public bool Valid_key { get; set; }
        public Results Results { get; set; }
        public double Execution_time { get; set; }
        public bool From_cache { get; set; }
    }
}