using StoneClimaTempo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneClimaTempo.Services.Interfaces
{
    public interface ICityService
    {

        void PopulateCityWithTemperatures(CityTemperatures city);

        void ClearTemperaturesFromCity(CityTemperatures city);

        List<CityTemperatures> LoadHottestCities(List<CityTemperatures> cities);

    }
}
