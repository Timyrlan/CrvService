using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Logic.ClientSide
{
    public static class Name
    {
        public static string Get<TInterface>() where TInterface : IEntityBase
        {
            var name = typeof(TInterface).Name;
            name = Get(name);
            return name;
        }

        public static string Get(string name)
        {
            if (name[0] == 'I') name = name.Substring(1);
            return name;
        }
    }
}