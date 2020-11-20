using CrvService.Shared.Contracts.Dto.Base;

namespace CrvService.Shared.Contracts.Dto.Commands.ServerCommands.Base
{
    public class ServerCommandDto : DtoBase
    {
        public int Id { get; set; }

        public string PlayerGuid { get; set; }
        public string WorldGuid { get; set; }

        public string CityGuid { get; set; }
    }
}