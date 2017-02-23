using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperaturesLoader.Consumers.Interfaces
{
    interface ICityConsumer
    {
        /// <summary>
        /// Método que retorna dados de temperatura a oartir do nome de uma cidade
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        object LoadTemperaturesData(string cityName);
    }
}
