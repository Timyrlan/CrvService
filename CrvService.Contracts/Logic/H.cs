using System;
using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Logic
{
    public static class H
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

        public static Tuple<string, string> InitializeBaseEntity(object thisObj)
        {
            var type = thisObj.GetType().Name.Replace("ClientSideEntity", string.Empty).Replace("Entity", string.Empty);
            var guid = Guid.NewGuid().ToString();
            return new Tuple<string, string>(type, guid);
        }

        public static T Cast<T>(object c) where T : class
        {
            var result = c as T;
            if (result == null) throw new Exception($"Argument type='{c?.GetType().Name}' not castble to '{typeof(T).Name}'");
            return result;
        }
    }
}