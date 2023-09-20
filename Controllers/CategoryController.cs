using Microsoft.AspNetCore.Mvc;
using PRACTICA_JQUERY_AJAX.Services.Categorias;

namespace PRACTICA_JQUERY_AJAX.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListaCategorias()
        {
            var category = _categoryService.ObtenerCategorias().Result;
            return Json(category);
        }
    }
}
