using System;
using CrvService.Shared.Contracts.Dto.Base;

namespace CrvService.Shared.Contracts.Dto
{
    public class WorldDto : DtoBase
    {
        public DateTime WorldDate { get; set; }
        public CityDto[] Cities { get; set; } = { };
    }
}