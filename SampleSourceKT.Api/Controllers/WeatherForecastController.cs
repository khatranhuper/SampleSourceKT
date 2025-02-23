﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleSourceKT.Application.ServiceContracts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSourceKT.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IProductServices _productServices;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _productServices.Create(new Application.DTO.CreateProductRequest());
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
