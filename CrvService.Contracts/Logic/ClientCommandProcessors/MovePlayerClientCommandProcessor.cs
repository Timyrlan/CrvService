using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.ClientCommands;
using CrvService.Shared.Contracts.Entities.ClientCommands.Base;
using CrvService.Shared.Logic.ClientCommandProcessors.Base;

namespace CrvService.Shared.Logic.ClientCommandProcessors
{
    public class MovePlayerClientCommandProcessor : ClientCommandProcessorBase
    {
        public MovePlayerClientCommandProcessor(IProcessorsProvider processorsProvider) : base(processorsProvider)
        {
        }

        public override void Process(IClientCommand clientCommand, IWorld world, IPlayer player)
        {
            base.Process(clientCommand, world, player);

            var casted = H.Cast<IMovePlayerClientCommand>(clientCommand);
            player.MoveToX = casted.ToX;
            player.MoveToY = casted.ToY;
            player.IsMoving = true;
        }
    }
}