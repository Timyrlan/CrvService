using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrvService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public object Get()
        {
            return new HealthResult
            {
                Code = (int)HealthResult.HealthStatus.Ok,
                Status = "OK"
            };
        }
    }
}