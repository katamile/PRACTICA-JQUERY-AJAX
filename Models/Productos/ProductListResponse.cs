using Newtonsoft.Json;

namespace PRACTICA_JQUERY_AJAX.Models.Productos
{
    public class ProductListResponse
    {
        [JsonProperty("products")]
        public List<Products> Productos { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
