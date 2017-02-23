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

        void ClearTemperaturesFromCity(string cityName);

        List<CityTemperatures> LoadHottestCities(int quantity);

        List<CityTemperatures> LoadAllCities();

        CityTemperatures LoadCityByName(string cityName);

        void AddCityToProcessingList(string cityName);

        void RemoveCityToProcessingList(string cityName);

        void ClearAllCities();

    }
}
