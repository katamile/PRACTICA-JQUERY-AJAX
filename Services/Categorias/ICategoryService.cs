using PRACTICA_JQUERY_AJAX.Models.Categorias;

namespace PRACTICA_JQUERY_AJAX.Services.Categorias
{
    public interface ICategoryService
    {
        Task<List<Category>> ObtenerCategorias();
    }
}
