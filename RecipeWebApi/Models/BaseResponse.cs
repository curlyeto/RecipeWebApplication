using Microsoft.OpenApi.Any;

namespace RecipeWebApi.Models
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public String Message { get; set; }

        public T Data { get; set; }

    }
}
