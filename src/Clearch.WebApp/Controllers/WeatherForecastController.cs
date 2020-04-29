using System.Collections.Generic;
using System.Threading.Tasks;
using Clearch.Application.Abstractions;
using Clearch.Application.Abstractions.Queries;
using Clearch.Application.WeatherForecasts.Dtos;
using Clearch.Application.WeatherForecasts.Queries.List;
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
        private readonly ILogger<WeatherForecastController> logger;
        private readonly IQueryProcessor queryProcessor;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IQueryProcessor queryProcessor)
        {
            this.logger = logger;
            this.queryProcessor = queryProcessor;
        }

        [HttpGet]
        public async Task<IResult<IEnumerable<WeatherForecast>>> Get()
        {
            return await this.queryProcessor.ProcessAsync(new GetWeatherForecastListQuery()).ConfigureAwait(false);
        }
    }
}
