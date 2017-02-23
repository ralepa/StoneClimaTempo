﻿using StoneClimaTempo.Models;
using StoneClimaTempo.Services;
using StoneClimaTempo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace StoneClimaTempo.Cache
{
    /// <summary>
    /// Singleton de cache para guardar os dados sobre as temperaturas, funcionando como um in-memory database
    /// </summary>
    public class DataCache
    {
        private static DataCache instance;

        public List<CityTemperatures> Cities { get; private set; }
        private ICityService service;

        private DataCache()
        {
            Cities = new List<CityTemperatures>();
            service = new CityService();
            Thread thread = new Thread(ProcessTemperatureDataOnCities);
            thread.Start();
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


        private void ProcessTemperatureDataOnCities()
        {
            int sleepTime = Int32.Parse(Resource.SleepTime);
            while (true)
            {
                Thread.Sleep(sleepTime);
                Cities.ForEach(city =>
                {
                    service.PopulateCityWithTemperatures(city);
                });
            }
        }

        
    }
}