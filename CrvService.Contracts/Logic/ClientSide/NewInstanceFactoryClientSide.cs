using System;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Logic.ClientSide.Buildings;
using CrvService.Shared.Logic.ClientSide.Cargos;

namespace CrvService.Shared.Logic.ClientSide
{
    public class NewInstanceFactoryClientSide : INewInstanceFactory
    {
        public T GetNewInstance<T>(string type) where T : class, IEntityBase
        {
            T result = null;

            if (type == "World")
            {
                var cc = new WorldClientSideEntity();
                result = cc as T;
            }
            else if (type == "Player")
            {
                var cc = new PlayerClientSideEntity();
                result = cc as T;
            }

            else if (type == "City")
            {
                var cc = new CityClientSideEntity();
                result = cc as T;
            }
            else if (type == "Bramin")
            {
                var cc = new BraminClientSideEntity();
                result = cc as T;
            }
            else if (type == "LivingHouse")
            {
                var cc = new LivingHouseClientSideEntity();
                result = cc as T;
            }
            else if (type == "SaltEvaporationFactory")
            {
                var cc = new SaltEvaporationFactoryClientSideEntity();
                result = cc as T;
            }
            else if (type == "FreshWater")
            {
                var cc = new FreshWaterClientSideEntity();
                result = cc as T;
            }
            else if (type == "SaltWater")
            {
                var cc = new SaltWaterClientSideEntity();
                result = cc as T;
            }
            else if (type == "Salt")
            {
                var cc = new SaltClientSideEntity();
                result = cc as T;
            }
            else
            {
                throw new Exception($"Unexpected type='{typeof(T).Name}'");
            }


            if (result == null) throw new Exception($"Can't cast '{type}' to {typeof(T).Name}");

            return result;
        }
    }
}