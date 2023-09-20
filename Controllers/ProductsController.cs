using Microsoft.AspNetCore.Mvc;
using PRACTICA_JQUERY_AJAX.Models;
using PRACTICA_JQUERY_AJAX.Models.Productos;
using PRACTICA_JQUERY_AJAX.Services.Productos;

namespace PRACTICA_JQUERY_AJAX.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productoService;

        public ProductsController(IProductService productoService)
        {
            _productoService = productoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListaProductos(){
            var productos = _productoService.ObtenerProductos().Result;
            return Json(productos);
        }

        [HttpGet]
        public JsonResult VerProducto(int id)
        {
            var producto = _productoService.ObtenerProductoId(id).Result;
            return Json(producto);
        }

        [HttpPost]
        public JsonResult CrearProducto(
            [FromBody]Products products)
        {
            var producto = _productoService.CrearProducto(products);
            return Json(producto);
        }

        [HttpPut]
        public async Task<JsonResult> ActualizarProducto(
            [FromRoute] int id,
            [FromBody]Products products)
        {
            var producto = await _productoService.ActualizarProducto(id, products);
            return Json(producto);
        }

    }
}
