using Newtonsoft.Json;
using PRACTICA_JQUERY_AJAX.Models.Categorias;
using System.ComponentModel.DataAnnotations;

namespace PRACTICA_JQUERY_AJAX.Models.Productos
{
    public class Products
    {
        [JsonProperty("id")]
        [Display(Name = "#")]
        public int Id { get; set; }

        [JsonProperty("title")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [JsonProperty("description")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [JsonProperty("price")]
        [Display(Name = "PVP")]
        public double Precio { get; set; }

        [JsonProperty("images")]
        [Display(Name = "Imagen")]
        public List<string> Images { get; set; }

        [JsonProperty("category")]
        [Display(Name = "Categoría")]
        public Category Category { get; set; }

    }
}
