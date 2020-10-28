using System;
using System.Collections.Generic;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Contracts.Entities.ClientCommands;
using CrvService.Shared.Contracts.Entities.ClientCommands.Base;
using CrvService.Shared.Logic.ClientCommandProcessors;
using CrvService.Shared.Logic.ClientCommandProcessors.Base;
using CrvService.Shared.Logic.Processors;
using CrvService.Shared.Logic.Processors.Base;
using CrvService.Shared.Logic.Processors.Buildings;
using CrvService.Shared.Logic.Processors.Cargos;

namespace CrvService.Shared.Logic.ClientSide
{
    public class ProcessorsProvider : IProcessorsProvider
    {
        public ProcessorsProvider(INewInstanceFactory newInstanceFactory)
        {
            NewInstanceFactory = newInstanceFactory;

            #region Processors initialisation

            AddProcessor<IWorld>(new WorldProcessor(this));

            AddProcessor<IBramin>(new BraminProcessor(this));
            AddProcessor<ICity>(new CityProcessor(this));
            AddProcessor<IPlayer>(new PlayerProcessor(this));


            //Buildings
            AddProcessor<ILivingHouse>(new LivingHouseProcessor(this, NewInstanceFactory));
            AddProcessor<ISaltEvaporationFactory>(new SaltEvaporationFactoryProcessor(this, NewInstanceFactory));

            //Cargos
            AddProcessor<IFreshWater>(new FreshWaterProcessor(this));
            AddProcessor<ISaltWater>(new SaltWaterProcessor(this));
            AddProcessor<ISalt>(new SaltProcessor(this));

            #endregion

            #region ClientCommandProcessors initialisation

            AddClientCommandProcessor<IMovePlayerClientCommand>(new MovePlayerClientCommandProcessor(this));

            #endregion
        }


        private INewInstanceFactory NewInstanceFactory { get; }

        public Dictionary<string, IProcessor> Processors { get; } = new Dictionary<string, IProcessor>();
        public Dictionary<string, IClientCommandProcessor> ClientCommandProcessors { get; } = new Dictionary<string, IClientCommandProcessor>();

        public void Process(object entity)
        {
            var casted = Cast<IEntityBase>(entity);
            Processors[casted.Type].Process(casted);
        }

        public void ProcessClientCommand(IClientCommand clientCommand, IWorld world, IPlayer player)
        {
            ClientCommandProcessors[clientCommand.Type].Process(clientCommand, world, player);
        }


        private void AddProcessor<TInterface>(IProcessor processor) where TInterface : IEntityBase
        {
            Processors.Add(Name.Get<TInterface>(), processor);
        }

        private void AddClientCommandProcessor<TInterface>(IClientCommandProcessor processor) where TInterface : IEntityBase
        {
            ClientCommandProcessors.Add(Name.Get<TInterface>(), processor);
        }

        private T Cast<T>(object c) where T : class
        {
            var result = c as T;
            if (result == null) throw new Exception($"Argument type='{c?.GetType().Name}' not castble to '{typeof(T).Name}'");
            return result;
        }
    }
}