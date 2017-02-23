using Newtonsoft.Json;
using StoneClimaTempo.Models;
using StoneClimaTempo.Services;
using StoneClimaTempo.Services.Interfaces;
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

        private ICityService service;

        private CityController()
        {
            service = new CityService();
        }

        /// <summary>
        /// Obtém histórico de temperaturas de uma cidade
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("city/{cityName}")]
        public string Get(HttpRequestMessage request, string cityName)
        {
            CityTemperatures data = service.LoadCityByName(cityName);
            if(data == null)
            {
                request.CreateResponse(HttpStatusCode.NotModified);
                return String.Empty;
            }
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Cadastra uma nova cidade a ser monitorada
        /// </summary>
        /// <param name="name"></param>
        [HttpPost]
        [Route("city/{cityName}")]
        public void Post(HttpRequestMessage request, string cityName)
        {
            bool found = service.AddCityToProcessingList(cityName);
            if(!found)
            {
                request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Remove uma cidade do monitoramento
        /// </summary>
        /// <param name="cityName"></param>
        [HttpDelete]
        [Route("city/{cityName}")]
        public void Delete(HttpRequestMessage request, string cityName)
        {
            CityTemperatures data = service.LoadCityByName(cityName);
            if (data == null)
            {
                request.CreateResponse(HttpStatusCode.NotModified);
                return;
            }
            service.RemoveCityToProcessingList(cityName);
        }

        /// <summary>
        /// Limpa o histórico de temperaturas de uma cidade
        /// </summary>
        /// <param name="cityName"></param>
        [HttpPatch]
        [Route("city/{cityName}")]
        public void Patch(HttpRequestMessage request, string cityName)
        {
            CityTemperatures data = service.LoadCityByName(cityName);
            if (data == null)
            {
                request.CreateResponse(HttpStatusCode.NotModified);
                return;
            }
            service.ClearTemperaturesFromCity(cityName);
        }


        /// <summary>
        /// Retorna a lista das 3 cidades com a maior temperatura já registrada.
        /// </summary>
        [HttpGet]
        [Route("cities/max_temperatures")]
        public string GetTopMaxTemperatures(HttpRequestMessage request)
        {
            List<CityTemperatures> data = service.LoadHottestCities(3);
            return JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        [Route("city/by_cep/{cep}")]
        public void PostByCep(HttpRequestMessage request, string cep)
        {
            bool found = service.AddCityToProcessingListByCep(cep);
            if (!found)
            {
                request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

    }
}
