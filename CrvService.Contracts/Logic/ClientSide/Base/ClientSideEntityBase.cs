using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Logic.ClientSide.Base
{
    public abstract class ClientSideEntityBase : IEntityBase
    {
        protected ClientSideEntityBase()
        {
            var c = H.InitializeBaseEntity(this);
            Type = c.Item1;
            Guid = c.Item2;
        }

        public string Guid { get; set; }
        public string Type { get; set; }
    }
}