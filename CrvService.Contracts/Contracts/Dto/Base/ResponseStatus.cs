namespace CrvService.Shared.Contracts.Dto.Base
{
    public class ResponseStatus
    {
        public int Code = (int) ResponseStatusEnum.Success;
        public string ErrorMessage { get; set; }
    }
}