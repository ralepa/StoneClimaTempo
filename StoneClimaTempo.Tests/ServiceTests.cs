using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoneClimaTempo.Models;
using StoneClimaTempo.Cache;
using StoneClimaTempo.Services.Interfaces;
using StoneClimaTempo.Services;

namespace StoneClimaTempo.Tests
{
    /// <summary>
    /// Classe de testes para a camada de serviço
    /// </summary>
    [TestClass]
    public class ServiceTests
    {

        ICityService service;

        private string[] cityNames = { "Rio de Janeiro", "São Paulo", "Curitiba" } ;
        
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        
        public ServiceTests()
        {
            service = new CityService();
        }

        [TestMethod]
        public void TestLoadAllCities()
        {
            ClearTestList();

            Assert.IsTrue(service.LoadAllCities().Count == 0);

            service.AddCityToProcessingList(cityNames[0]);
            service.AddCityToProcessingList(cityNames[1]);
            service.AddCityToProcessingList(cityNames[2]);

            Assert.IsTrue(service.LoadAllCities().Count == 3);
        }

        [TestMethod]
        public void TestLoadCityByName()
        {
            ClearTestList();
            string cityName = cityNames[1];
            service.AddCityToProcessingList(cityName);

            List<CityTemperatures> cities = service.LoadAllCities();

            Assert.IsTrue(cities.Count == 1, "Lista de cidades deveria conter 1 elemento");

            CityTemperatures city = service.LoadCityByName(cityName);

            Assert.IsNotNull(city);
        }


        [TestMethod]
        public void TestAddCityToProcessingList()
        {
            ClearTestList();
            string city1 = cityNames[0];
            string city2 = cityNames[1];
            service.AddCityToProcessingList(city1);
            List<CityTemperatures> cities = service.LoadAllCities();
            CollectionAssert.AllItemsAreNotNull(cities);
            Assert.IsNotNull(cities);
            Assert.IsTrue(cities.Count == 2);
        }

        [TestMethod]
        public void TestClearTemperaturesFromCity()
        {
            ClearTestList();
            // Cidade exclusiva para esse teste
            string cityName = "Belo Horizonte";
            service.AddCityToProcessingList(cityName);
            CityTemperatures city = service.LoadCityByName(cityName);

            // Cidade foi registrada com sucesso
            Assert.IsNotNull(city);
            service.ClearTemperaturesFromCity(cityName);
        }

        /// <summary>
        /// Limpa a lista com os itens possíveis
        /// </summary>
        private void ClearTestList()
        {
            // Garantir que a lista estará vazia
            service.RemoveCityToProcessingList(cityNames[0]);
            service.RemoveCityToProcessingList(cityNames[1]);
            service.RemoveCityToProcessingList(cityNames[2]);
        }

        [TestMethod]
        public void TestLoadHottestCities()
        {
            ClearTestList();

            Assert.IsTrue(service.LoadAllCities().Count == 0);

            service.AddCityToProcessingList(cityNames[0]);
            service.AddCityToProcessingList(cityNames[1]);
            service.AddCityToProcessingList(cityNames[2]);

            List<CityTemperatures> allCities = service.LoadAllCities();

            Assert.IsTrue(allCities.Count == 3, "Lista deveria ter 3 elementos");

            foreach(CityTemperatures city in allCities)
            {
                service.PopulateCityWithTemperatures(city);
            }
            
            List<CityTemperatures> list1 = service.LoadHottestCities(3);
            List<CityTemperatures> list2 = service.LoadHottestCities(0);
            List<CityTemperatures> list3 = service.LoadHottestCities(2);

            Assert.IsTrue(list1.Count == 3, "Lista 1 não tem 3 elementos");
            Assert.IsTrue(list2.Count == 0, "Lista 2 não está vazia");
            Assert.IsTrue(list3.Count == 2, "Lista 3 não tem 2 elementos");
        }

        [TestMethod]
        public void PopulateCityWithTemperatures()
        {
            ClearTestList();
            service.AddCityToProcessingList(cityNames[0]);

            CityTemperatures city = service.LoadCityByName(cityNames[0]);

            service.PopulateCityWithTemperatures(city);

            Assert.IsTrue(city.Temperatures.Count > 0);

        }

        [TestMethod]
        public void RemoveCityToProcessingList()
        {
            ClearTestList();
            service.AddCityToProcessingList(cityNames[0]);

            List<CityTemperatures> cities = service.LoadAllCities();

            Assert.IsTrue(cities.Count == 1, "Lista de cidades deveria conter 1 elemento");

            service.RemoveCityToProcessingList(cityNames[0]);

            Assert.IsTrue(cities.Count == 0, "Lista de cidades deveria estar vazia");

        }
    }
}
