using StoneClimaTempo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperaturesLoader.Consumers.Interfaces
{
    public interface ICepConsumer
    {
        /// <summary>
        /// Método que retorna o nome da cidade pelo CEP
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        CepData LoadCityNameByCep(string cep);
    }
}
