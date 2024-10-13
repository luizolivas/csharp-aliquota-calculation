using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using Aliquota.Domain.Webapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aliquota.Domain.Webapp.Controllers
{
    public class ProdutoFinanceiroController : Controller
    {
        private readonly IProdutoFinanceiroService _produtoFinanceiroService;

        public ProdutoFinanceiroController(IProdutoFinanceiroService produtoFinanceiroService)
        {
            _produtoFinanceiroService = produtoFinanceiroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> NovoProdutoFinanceiro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProdutoFinanceiroViewModel produtoVM)
        {
            //if (ModelState.IsValid)
            //{
            //    var result = await _productService.CreateProduct(productVM);

            //    if (result != null)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //}
            //else
            //{
            //    var categories = await _categoryService.GetAllCategories();
            //    ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            //}

            //return View(productVM);
            return View();
        }
    }
}
