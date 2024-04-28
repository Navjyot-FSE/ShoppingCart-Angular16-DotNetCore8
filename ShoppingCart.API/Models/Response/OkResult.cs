using System.Net;
using System.Text.Json.Serialization;

namespace ShoppingCart.Models.Response
{
    public class OkResult<T> where T : class 
    {
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; } = (int)HttpStatusCode.OK;

        [JsonPropertyName("statusMesage")]
        public string StatusMesage { get; set; } = "Retrived Successfully";

        [JsonPropertyName("data")]
        public T? Data  { get; set; }
    }
}