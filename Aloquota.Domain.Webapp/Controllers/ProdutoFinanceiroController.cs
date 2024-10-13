using Aliquota.Domain.Models;
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
            if (ModelState.IsValid)
            {
                ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro()
                {
                    Nome = produtoVM.Nome,
                    Valor = produtoVM.Valor
                };

                await _produtoFinanceiroService.AddProduto(produtoFinanceiro);
                return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "Erro ao adicionar o produto.");
            return View(produtoVM);

        }
    }
}
