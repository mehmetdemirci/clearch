using Clearch.Application.Abstractions;
using Clearch.Application.Abstractions.Queries;
using Clearch.Application.Common;
using Clearch.Application.WeatherForecasts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clearch.Application.WeatherForecasts.Queries.List
{
    public class GetWeatherForecastListQueryHandler : IQueryHandler<GetWeatherForecastListQuery, IEnumerable<WeatherForecast>>
    {
        private readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<IResult<IEnumerable<WeatherForecast>>> Handle(GetWeatherForecastListQuery request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var vm = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            return Result<IEnumerable<WeatherForecast>>.SuccessAsync(vm);
        }
    }
}
