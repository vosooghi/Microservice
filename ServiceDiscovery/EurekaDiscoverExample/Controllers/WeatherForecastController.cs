using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace EurekaDiscoverExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger _logger;
        DiscoveryHttpClientHandler _handler;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDiscoveryClient client)
        {
            _logger = logger;
            _handler = new DiscoveryHttpClientHandler(client);
        }

        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            var client = new HttpClient(_handler, false);
            return await client.GetStringAsync("http://EurekaRegisterExample/WeatherForecast");
        }
    }
}
