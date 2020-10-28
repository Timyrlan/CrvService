using System;
using CrvService.Shared.Contracts.Dto.Base;

namespace CrvService.Shared.Contracts.Dto
{
    public class WorldDto : DtoBase
    {
        public CityDto[] Cities = { };
        public DateTime WorldDate;
    }
}