using Microsoft.AspNetCore.Http;

namespace Gym.Domain.Interfaces
{
    public interface IApiResponse
    {
        public string Message { get; set; }

        public string? Tecnical { get; set; }

        public bool Result { get; set; }

        public int StatusCode { get; set; }
    }

    public interface IApiResponse<T> where T : class
    {
        public string Message { get; set; }

        public string? Tecnical { get; set; }

        public bool Result { get; set; }
        public int StatusCode { get; set; }
    }
}
