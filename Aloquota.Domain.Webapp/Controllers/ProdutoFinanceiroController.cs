using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aliquota.Domain.Webapp.Controllers
{
    public class ProdutoFinanceiroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            //var categories = await _categoryService.GetAllCategories();
            //ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            return View();
        }
    }
}
