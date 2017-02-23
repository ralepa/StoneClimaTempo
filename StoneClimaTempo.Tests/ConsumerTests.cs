using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemperaturesLoader.Consumers;
using TemperaturesLoader.Consumers.Interfaces;

namespace StoneClimaTempo.Tests
{
    /// <summary>
    /// Classe de teste para City e suas funções
    /// </summary>
    [TestClass]
    public class ConsumerTest
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
        /// Testa obtenção de dados da API de temperaturas
        /// </summary>
        [TestMethod]
        public void CityTemperaturesAPIShouldReturnData()
        {
            ICityConsumer consumer = new CityConsumer();
            var cityName = "Rio de Janeiro";
            DTOs.TemperaturesData result = consumer.LoadTemperaturesData(cityName);

            Assert.IsNotNull(result);       
        }
    }
}
