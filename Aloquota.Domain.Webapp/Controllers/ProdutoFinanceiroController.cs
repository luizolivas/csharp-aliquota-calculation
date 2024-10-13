using Aliquota.Domain.Models;
using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using Aliquota.Domain.Webapp.Mappers;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoFinanceiroViewModel>>> Index()
        {
            var result = await _produtoFinanceiroService.GetProdutos();
            if(result == null)
            {
                return View("Error");
            }

            var viewModel = ProdutoFinanceiroMapper.ToViewModel(result);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> NovoProdutoFinanceiro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriaProduto(ProdutoFinanceiroViewModel produtoVM)
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

        [HttpGet]
        public IActionResult AtualizaProduto(ProdutoFinanceiroViewModel produtoVM)
        {
            return View();
        }



        [HttpGet]
        public IActionResult DeletaProduto(ProdutoFinanceiroViewModel produtoVM)
        {
            return View();
        }
    }
}
