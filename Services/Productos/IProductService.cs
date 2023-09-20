using PRACTICA_JQUERY_AJAX.Models.Productos;

namespace PRACTICA_JQUERY_AJAX.Services.Productos
{
    public interface IProductService
    {
        Task<List<Products>> ObtenerProductos();

        Task<Products> ObtenerProductoId(
            int id);

        Task<Products> CrearProducto(
            Products producto);

        Task<Products> ActualizarProducto(
            int id,
            Products products);
    }
}
