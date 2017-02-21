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

        [TestMethod]
        public void CityShouldOnlyConstructWithName()
        {
            Models.City cityTest = new Models.City("Rio de Janeiro");
            Assert.IsNotNull(cityTest);

            string cityName = cityTest.Name;
            Assert.IsNotNull(cityName);
        }
    }
}
