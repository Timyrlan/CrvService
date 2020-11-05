using Microsoft.Extensions.Options;

namespace CrvService.Data
{
    public class OptionsStub<T> : IOptions<T> where T : class, new()
    {
        public OptionsStub(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}