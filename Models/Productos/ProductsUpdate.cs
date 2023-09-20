using Newtonsoft.Json;
using PRACTICA_JQUERY_AJAX.Models.Categorias;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PRACTICA_JQUERY_AJAX.Models.Productos
{
    public class ProductsUpdate
    {
        [JsonProperty("title")]
        public string Titulo { get; set; }

        [JsonProperty("description")]
        public string Descripcion { get; set; }

        [JsonProperty("price")]
        public double Precio { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

    }
}
