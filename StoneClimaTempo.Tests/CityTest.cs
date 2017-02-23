using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StoneClimaTempo.Tests
{
    /// <summary>
    /// Classe de teste para City e suas funções
    /// </summary>
    [TestClass]
    public class CityTest
    {
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

        /// <summary>
        /// Cria uma instância de cidade com o nome devido
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Models.CityTemperatures CreateMockCity(string name)
        {
            return new Models.CityTemperatures(name);
        }

        /// <summary>
        /// Método para adicionar temperaturas aleatórias numa quantidade definida na cidade passada
        /// </summary>
        /// <param name="city"></param>
        /// <param name="quantity"></param>
        private void AddTestTemperatures(Models.CityTemperatures city, int quantity)
        {
            Random random = new Random();
            DateTime dateTime = new DateTime();
            for (var i = 0; i < quantity; i++)
            {
                // Número aleatório de 20 a 40 
                double temperature = random.NextDouble() * 20 + 20;
                city.AddTemperatureRegistry(dateTime, temperature);
            }
        }

        /// <summary>
        /// Testa se um objeto básico é criado somente com nome
        /// </summary>
        [TestMethod]
        public void CityShouldOnlyConstructWithName()
        {
            Models.CityTemperatures cityTest = CreateMockCity("Rio de Janeiro");
            Assert.IsNotNull(cityTest);

            string cityName = cityTest.City;
            Assert.IsNotNull(cityName);
        }

        /// <summary>
        /// Testa se as temperaturas são gravadas no registro
        /// </summary>
        [TestMethod]
        public void CityShouldAddTemperatureInfo()
        {
            Models.CityTemperatures cityTest = CreateMockCity("São Paulo");

            AddTestTemperatures(cityTest, 2);

            Assert.IsNotNull(cityTest.Temperatures);
            Assert.IsTrue(cityTest.Temperatures.Count == 2);
        }

        /// <summary>
        /// Testa se a lista com temperaturas é preenchida e depois esvaziada
        /// </summary>
        [TestMethod]
        public void CityShouldClearTemperaturesInfo()
        {
            Models.CityTemperatures cityTest = CreateMockCity("São Paulo");

            // Adiciona 5 temperaturas aleatórias
            AddTestTemperatures(cityTest, 5);            
            Assert.IsTrue(cityTest.Temperatures.Count == 5);
            
            // Reseta a lista de temperaturas
            cityTest.ResetRegistries();
            Assert.IsTrue(cityTest.Temperatures.Count == 0);
        }
    }
}
