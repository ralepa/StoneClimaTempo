using Microsoft.Practices.Unity;
using StoneClimaTempo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemperaturesLoader.Consumers;
using TemperaturesLoader.Consumers.Interfaces;

namespace StoneClimaTempo.Services
{

    public class CepService:ICepService
    {
        
        private readonly ICepConsumer consumer;
        
        /// <summary>
        /// Construtor do serviço de CEP
        /// </summary>
        private CepService()
        {
            this.consumer = new CepConsumer();
        }

        public string LoadCityNameByCep(string cep)
        {
            throw new NotImplementedException();
        }
    }
}