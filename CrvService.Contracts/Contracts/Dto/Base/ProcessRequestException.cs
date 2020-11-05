using System;

namespace CrvService.Shared.Contracts.Dto.Base
{
    public class ProcessRequestException : Exception
    {
        public ProcessRequestException(ResponseStatusEnum code, string message) : base(message)
        {
            Code = code;
        }

        public ResponseStatusEnum Code { get; }
    }

    public class ProcessBadRequestException : ProcessRequestException
    {
        public ProcessBadRequestException(string message) : base(ResponseStatusEnum.BadRequest, message)
        {
        }
    }
}