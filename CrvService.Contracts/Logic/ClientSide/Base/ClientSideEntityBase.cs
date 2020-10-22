using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Logic.ClientSide.Base
{
    public abstract class ClientSideEntityBase : IEntityBase
    {
        protected ClientSideEntityBase()
        {
            Type = GetType().Name.Replace("ClientSideEntity", string.Empty);
            Guid = System.Guid.NewGuid().ToString();
        }

        public string Guid { get; set; }
        public string Type { get; set; }
    }
}