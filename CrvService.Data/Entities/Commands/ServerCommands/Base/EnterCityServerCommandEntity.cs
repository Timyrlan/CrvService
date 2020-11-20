using CrvService.Shared.Contracts.Entities.Commands.ServerCommands;

namespace CrvService.Data.Entities.Commands.ServerCommands.Base
{
    public class EnterCityServerCommandEntity : ServerCommandEntity, IEnterCityServerCommand
    {
        public string CityGuid { get; set; }
    }
}