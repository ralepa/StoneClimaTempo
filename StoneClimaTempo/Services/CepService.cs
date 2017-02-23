using Microsoft.Practices.Unity;
using StoneClimaTempo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemperaturesLoader.Consumers.Interfaces;

namespace StoneClimaTempo.Services
{

    public class CepService:ICepService
    {
        
        private readonly ICepConsumer consumer;
        
        [InjectionConstructor]
        private CepService(ICepConsumer consumer)
        {
            this.consumer = consumer;
        }

    }
}