using System;
using System.Threading.Tasks;
using CrvService.Logging;
using CrvService.Shared.Contracts.Dto;
using CrvService.Shared.Contracts.Dto.Base;
using CrvService.Shared.Logic;
using CrvService.Shared.Logic.ClientSide.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrvService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;

        public PingController(
            ILogger<PingController> logger,
            ICaravanServer caravanServer)
        {
            CaravanServer = caravanServer;
            _logger = logger;
        }

        private ICaravanServer CaravanServer { get; }


        [HttpPost]
        public async Task<ProcessWorldResponse> Get([FromBody] ProcessWorldRequest request)
        {
            try
            {
                var mapped = ToClientSideMapper.Map(request);
                var result = await CaravanServer.ProcessWorldAsync(mapped);
                var response = ToDtoMapper.Map(result);
                return response;
            }
            catch (ProcessRequestException e)
            {
                var result = new ProcessWorldResponse
                {
                    Status = new ResponseStatus {Code = (int) e.Code, ErrorMessage = e.Message}
                };
                _logger.LogError(e, $"Error ProcessRequestException {GetType().Name} with request='{request.ToLog()}', response='{result.ToLog()}'");
                return result;
            }
            catch (Exception e)
            {
                var result = new ProcessWorldResponse
                {
                    Status = new ResponseStatus {Code = (int) ResponseStatusEnum.InernalError, ErrorMessage = e.Message}
                };
                _logger.LogError(e, $"Error InternalServerError {GetType().Name} with request='{request.ToLog()}', response='{result.ToLog()}'");
                return result;
            }
        }
    }
}