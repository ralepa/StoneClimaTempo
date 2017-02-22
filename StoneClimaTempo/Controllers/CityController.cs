using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoneClimaTempo.Controllers
{
    public class CityController : ApiController
    {

        /// <summary>
        /// Obtém histórico de temperaturas de uma cidade
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("city/{cityName}")]
        public string Get(string cityName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastra uma nova cidade a ser monitorada
        /// </summary>
        /// <param name="name"></param>
        [HttpPost]
        [Route("city/{cityName}")]
        public void Post(string cityName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove uma cidade do monitoramento
        /// </summary>
        /// <param name="cityName"></param>
        [HttpDelete]
        [Route("city/{cityName}")]
        public void Delete(string cityName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Limpa o histórico de temperaturas de uma cidade
        /// </summary>
        /// <param name="cityName"></param>
        [HttpPatch]
        [Route("city/{cityName}")]
        public void Patch(string cityName)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Retorna a lista das 3 cidades com a maior temperatura já registrada.
        /// </summary>
        [HttpGet]
        [Route("cities/max_temperatures")]
        public void GetTopMaxTemperatures()
        {
            throw new NotImplementedException();
        }

    }
}
