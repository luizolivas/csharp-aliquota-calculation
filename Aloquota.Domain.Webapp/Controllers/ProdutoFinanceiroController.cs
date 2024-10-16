using Aliquota.Domain.Models;
using Aliquota.Domain.Services.ClienteService.Contract;
using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using Aliquota.Domain.Webapp.Mappers;
using Aliquota.Domain.Webapp.Models;
using Aliquota.Domain.Webapp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aliquota.Domain.Webapp.Controllers
{
    public class ProdutoFinanceiroController : Controller
    {
        private readonly IProdutoFinanceiroService _produtoFinanceiroService;
        private readonly IClienteService _clienteService;
        private readonly IClienteServiceFront _clienteServiceFront;

        public ProdutoFinanceiroController(IProdutoFinanceiroService produtoFinanceiroService, IClienteService clienteService, IClienteServiceFront clienteServiceFront)
        {
            _produtoFinanceiroService = produtoFinanceiroService;
            _clienteService = clienteService;
            _clienteServiceFront = clienteServiceFront;

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
            
            ViewBag.ClienteId = await _clienteServiceFront.GetListaClientes();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriaProduto(ProdutoFinanceiroViewModel produtoVM)
        {
            ModelState.Remove("NomeCliente");

            if (ModelState.IsValid)
            {
                ProdutoFinanceiro produtoFinanceiro = ProdutoFinanceiroMapper.ToModel(produtoVM);

                await _produtoFinanceiroService.AddProduto(produtoFinanceiro);
                return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "Erro ao adicionar o produto.");
            return View(produtoVM);

        }

        [HttpGet]
        public async Task<IActionResult> AtualizaProduto(int id)
        {
            ViewBag.ClienteId = await _clienteServiceFront.GetListaClientes();
            var result = await _produtoFinanceiroService.GetProdutobyId(id);

            if (result is null)
            {
                return View("Error");
            }
            var viewModel = ProdutoFinanceiroMapper.ToViewModel(result);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizaProduto(ProdutoFinanceiroViewModel produtoVM)
        {
            ModelState.Remove("NomeCliente");

            if (ModelState.IsValid)
            {
                var produtoFinanceiro = ProdutoFinanceiroMapper.ToModel(produtoVM);
                
                await _produtoFinanceiroService.UpdateProduto(produtoFinanceiro);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Erro ao atualizar o produto.");
            return View(produtoVM);
        }



        [HttpGet]
        public async Task<IActionResult> DeletaProduto(ProdutoFinanceiroViewModel produtoVM)
        {
            ViewBag.ClienteId = await _clienteServiceFront.GetListaClientes();
            var result = await _produtoFinanceiroService.GetProdutobyId(produtoVM.Id);

            if (result is null)
            {
                return View("Error");
            }
            var viewModel = ProdutoFinanceiroMapper.ToViewModel(result);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletaProduto(int id)
        {
            ModelState.Remove("NomeCliente");

            if (ModelState.IsValid)
            {
                await _produtoFinanceiroService.DeleteProduto(id);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Erro ao excluir o produto.");
            return View();
        }

        [HttpGet] 
        public async Task<IActionResult> AplicaProduto(ProdutoFinanceiroViewModel produtoVM)
        {
            return RedirectToAction("AplicaProduto", "Movimentacao", new { id = produtoVM.Id });
        }

    }
}
