using Newtonsoft.Json;
using PRACTICA_JQUERY_AJAX.Models.Productos;

namespace PRACTICA_JQUERY_AJAX.Models.Categorias
{
    public class CategoryListResponse
    {
        [JsonProperty("categories")]
        public List<Category> Category { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
