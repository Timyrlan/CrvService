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
    public class GetNewWorldController : ControllerBase
    {
        private readonly ILogger<GetNewWorldController> _logger;

        public GetNewWorldController(
            ILogger<GetNewWorldController> logger,
            ICaravanServer caravanServer)
        {
            CaravanServer = caravanServer;
            _logger = logger;
        }

        private ICaravanServer CaravanServer { get; }


        [HttpPost]
        public async Task<ProcessWorldResponse> Get([FromBody] GetNewWorldRequest request)
        {
            try
            {
                var mapped = ToClientSideMapper.Map(request);
                var result = await CaravanServer.GetNewWorldAsync(mapped);
                var response = ToDtoMapper.Map(result);
                return response;
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