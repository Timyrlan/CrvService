using System.Collections.Generic;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Contracts.Entities.Cargos.Base;
using CrvService.Shared.Logic.ClientSide;
using CrvService.Shared.Logic.ClientSide.Cargos;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic.Processors.Buildings
{
    public class SaltEvaporationFactoryProcessor : BuildingProcessor
    {
        public SaltEvaporationFactoryProcessor(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory) : base(processorsProvider, newInstanceFactory)
        {
        }

        public override IProduce[] Produces { get; set; } =
        {
            new ProduceClientSideEntity
            {
                From = new ICargo[] {new SaltWaterClientSideEntity {Count = 1m}},
                To = new ICargo[]
                {
                    new FreshWaterClientSideEntity {Count = 0.95m},
                    new SaltClientSideEntity {Count = 0.05m}
                },
                Speed = 0.01m
            }
        };

        public override Dictionary<string, decimal> CanStoreCargos { get; set; } = new Dictionary<string, decimal>
        {
            {"SaltWater", 100},
            {"FreshWater", 100},
            {"Salt", 100}
        };

        public override void Process(object entity)
        {
            var casted = H.Cast<ISaltEvaporationFactory>(entity);
            base.Process(casted);
        }
    }
}