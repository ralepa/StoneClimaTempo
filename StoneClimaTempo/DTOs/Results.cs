using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneClimaTempo.DTOs
{
    public class Results
    {
        public int Temp { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Condition_code { get; set; }
        public string Description { get; set; }
        public string Currently { get; set; }
        public string Cid { get; set; }
        public string City { get; set; }
        public string Img_id { get; set; }
        public string Humidity { get; set; }
        public string Wind_speedy { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Condition_slug { get; set; }
        public string City_name { get; set; }
        public List<Forecast> Forecast { get; set; }
    }
}