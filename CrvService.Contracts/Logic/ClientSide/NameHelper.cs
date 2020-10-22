using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Logic.ClientSide
{
    public static class NameHelper
    {
        public static string GetNamefromInterface<TInterface>() where TInterface : IEntityBase
        {
            var name = typeof(TInterface).Name;
            if (name[0] == 'I') name = name.Substring(1);
            return name;
        }
    }
}