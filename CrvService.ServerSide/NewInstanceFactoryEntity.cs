using System;
using CrvService.Data.Entities;
using CrvService.Data.Entities.Buildings;
using CrvService.Data.Entities.Cargos;
using CrvService.Data.Entities.Commands.ServerCommands.Base;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Contracts.Entities.Cargos.Base;
using CrvService.Shared.Contracts.Entities.Commands.ServerCommands;
using CrvService.Shared.Logic;

namespace CrvService.ServerSide
{
    public class NewInstanceFactoryEntity : INewInstanceFactory
    {
        public T GetNewInstance<T>(string type) where T : class, IEntityBase
        {
            T result = null;

            type = H.Get(type);

            if (type == H.Get<IWorld>())
            {
                var cc = new WorldEntity();
                result = cc as T;
            }
            else if (type == H.Get<IPlayer>())
            {
                var cc = new PlayerEntity();
                result = cc as T;
            }

            else if (type == H.Get<ICity>())
            {
                var cc = new CityEntity();
                result = cc as T;
            }
            else if (type == H.Get<IBramin>())
            {
                var cc = new BraminEntity();
                result = cc as T;
            }
            else if (type == H.Get<ILivingHouse>())
            {
                var cc = new LivingHouseEntity();
                result = cc as T;
            }
            else if (type == H.Get<ISaltEvaporationFactory>())
            {
                var cc = new SaltEvaporationFactoryEntity();
                result = cc as T;
            }
            else if (type == H.Get<IFreshWater>())
            {
                var cc = new FreshWaterEntity();
                result = cc as T;
            }
            else if (type == H.Get<ISaltWater>())
            {
                var cc = new SaltWaterEntity();
                result = cc as T;
            }
            else if (type == H.Get<ISalt>())
            {
                var cc = new SaltEntity();
                result = cc as T;
            }
            else if (type == H.Get<IEnterCityServerCommand>())
            {
                var cc = new EnterCityServerCommandEntity();
                result = cc as T;
            }
            else
            {
                throw new Exception($"Unexpected type='{type}'");
            }

            if (result == null) throw new Exception($"Can't cast '{type}' to {typeof(T).Name}");

            return result;
        }

        public T GetNewInstance<T>() where T : class, IEntityBase
        {
            var type = H.Get<T>();
            return GetNewInstance<T>(type);
        }

        public T GetCargoNewInstance<T>(decimal count) where T : class, IEntityBase
        {
            var cargo = GetNewInstance<T>() as ICargo;
            // ReSharper disable once PossibleNullReferenceException
            cargo.Count = count;
            return cargo as T;
        }
    }
}