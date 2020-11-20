using CrvService.Shared.Contracts.Entities.Commands.ServerCommands.Base;

namespace CrvService.Shared.Contracts.Entities.Commands.ServerCommands
{
    public interface IEnterCityServerCommand : IServerCommand
    {
        string CityGuid { get; set; }
    }
}