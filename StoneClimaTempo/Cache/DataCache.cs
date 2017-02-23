using StoneClimaTempo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneClimaTempo.Cache
{
    /// <summary>
    /// Singleton de cache para guardar os dados sobre as temperaturas, funcionando como um in-memory database
    /// </summary>
    public class DataCache
    {
        private static DataCache instance;

        public List<CityTemperatures> cities { get; private set; }

        private DataCache()
        {
            cities = new List<CityTemperatures>();
        }

        public static DataCache Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataCache();
                }
                return instance;
            }
        }

    }
}