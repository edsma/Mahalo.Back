

namespace Mahalo.Shared.DTOs
{
    public class ResponseQuery<T> where T : class
    {
        public List<T>? Data { get; set; }
        public string? total { get; set; }

    }
}
