using System;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Logic.ClientSide.Buildings;
using CrvService.Shared.Logic.ClientSide.Cargos;

namespace CrvService.Shared.Logic.ClientSide
{
    public class NewInstanceFactoryClientSide : INewInstanceFactory
    {
        public T GetNewInstance<T>(string type) where T : class, IEntityBase
        {
            T result = null;

            type = Name.Get(type);

            if (type == Name.Get<IWorld>())
            {
                var cc = new WorldClientSideEntity();
                result = cc as T;
            }
            else if (type == Name.Get<IPlayer>())
            {
                var cc = new PlayerClientSideEntity();
                result = cc as T;
            }

            else if (type == Name.Get<ICity>())
            {
                var cc = new CityClientSideEntity();
                result = cc as T;
            }
            else if (type == Name.Get<IBramin>())
            {
                var cc = new BraminClientSideEntity();
                result = cc as T;
            }
            else if (type == Name.Get<ILivingHouse>())
            {
                var cc = new LivingHouseClientSideEntity();
                result = cc as T;
            }
            else if (type == Name.Get<ISaltEvaporationFactory>())
            {
                var cc = new SaltEvaporationFactoryClientSideEntity();
                result = cc as T;
            }
            else if (type == Name.Get<IFreshWater>())
            {
                var cc = new FreshWaterClientSideEntity();
                result = cc as T;
            }
            else if (type == Name.Get<ISaltWater>())
            {
                var cc = new SaltWaterClientSideEntity();
                result = cc as T;
            }
            else if (type == Name.Get<ISalt>())
            {
                var cc = new SaltClientSideEntity();
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
            var type = Name.Get<T>();
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