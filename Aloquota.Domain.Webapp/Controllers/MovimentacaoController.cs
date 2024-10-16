using Aliquota.Domain.Services.ClienteService.Contract;
using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using Aliquota.Domain.Webapp.Mappers;
using Aliquota.Domain.Webapp.Models;
using Aliquota.Domain.Webapp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Domain.Webapp.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IProdutoFinanceiroService _produtoFinanceiroService;
        private readonly IClienteService _clienteService;
        private readonly IClienteServiceFront _clienteServiceFront;

        public MovimentacaoController(IProdutoFinanceiroService produtoFinanceiroService, IClienteService clienteService, IClienteServiceFront clienteServiceFront)
        {
            _produtoFinanceiroService = produtoFinanceiroService;
            _clienteService = clienteService;
            _clienteServiceFront = clienteServiceFront;
        }

        [HttpGet]
        public async Task<IActionResult> AplicaProduto(int id)
        {
            ViewBag.ClienteId = await _clienteServiceFront.GetListaClientes();
            var result = await _produtoFinanceiroService.GetProdutobyId(id);

            if (result is null)
            {
                return View("Error");
            }
            var viewModel = ProdutoFinanceiroMapper.ToViewModel(result);

            MovimentacaoProdutoViewModel model = new MovimentacaoProdutoViewModel();
            model.ProdutoFinanceiroViewModel = viewModel;

            return View(model);
        }
    }
}
