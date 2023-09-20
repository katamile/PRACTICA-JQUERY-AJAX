using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PRACTICA_JQUERY_AJAX.Models.Categorias
{
    public class Category
    {
        [JsonProperty("id")]
        [Display(Name = "#")]
        public int Id { get; set; }

        [JsonProperty("name")]
        [Display(Name = "Nombre")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe contener entre 3 y 30 caracteres.")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

    }
}
