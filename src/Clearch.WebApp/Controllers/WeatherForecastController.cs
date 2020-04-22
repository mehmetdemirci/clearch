using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clearch.Application.Abstractions.Commands;
using Clearch.Application.Abstractions.Queries;
using Clearch.Application.GetWeatherForecast;
using Clearch.Application.TestReminder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clearch.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;
        private readonly IQueryProcessor queryProcessor;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IQueryProcessor queryProcessor)
        {
            this.logger = logger;
            this.queryProcessor = queryProcessor;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await this.queryProcessor.ProcessAsync(new GetWeatherForecastListQuery()).ConfigureAwait(false);
        }

    }
}
