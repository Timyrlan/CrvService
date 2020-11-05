using System;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Contracts.Entities.Cargos.Base;
using CrvService.Shared.Logic.ClientSide.Buildings;
using CrvService.Shared.Logic.ClientSide.Cargos;

namespace CrvService.Shared.Logic.ClientSide
{
    public class NewInstanceFactoryClientSide : INewInstanceFactory
    {
        public NewInstanceFactoryClientSide(IWorldRepository worldRepository, IPlayerRepository playerRepository)
        {
            WorldRepository = worldRepository;
            PlayerRepository = playerRepository;
        }

        private IWorldRepository WorldRepository { get; }
        private IPlayerRepository PlayerRepository { get; }

        public T GetNewInstance<T>(string type) where T : class, IEntityBase
        {
            T result = null;

            type = H.Get(type);

            if (type == H.Get<IWorld>())
            {
                var cc = new WorldClientSideEntity();
                WorldRepository.Add(cc);
                result = cc as T;
            }
            else if (type == H.Get<IPlayer>())
            {
                var cc = new PlayerClientSideEntity();
                PlayerRepository.Add(cc);
                result = cc as T;
            }

            else if (type == H.Get<ICity>())
            {
                var cc = new CityClientSideEntity();
                result = cc as T;
            }
            else if (type == H.Get<IBramin>())
            {
                var cc = new BraminClientSideEntity();
                result = cc as T;
            }
            else if (type == H.Get<ILivingHouse>())
            {
                var cc = new LivingHouseClientSideEntity();
                result = cc as T;
            }
            else if (type == H.Get<ISaltEvaporationFactory>())
            {
                var cc = new SaltEvaporationFactoryClientSideEntity();
                result = cc as T;
            }
            else if (type == H.Get<IFreshWater>())
            {
                var cc = new FreshWaterClientSideEntity();
                result = cc as T;
            }
            else if (type == H.Get<ISaltWater>())
            {
                var cc = new SaltWaterClientSideEntity();
                result = cc as T;
            }
            else if (type == H.Get<ISalt>())
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