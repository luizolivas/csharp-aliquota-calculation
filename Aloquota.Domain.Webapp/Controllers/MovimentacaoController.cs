﻿using Aliquota.Domain.Models;
using Aliquota.Domain.Services.ClienteService.Contract;
using Aliquota.Domain.Services.MovimentacaoService.Contracts;
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
        private readonly IClienteServiceFront _clienteServiceFront;
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacaoController(IProdutoFinanceiroService produtoFinanceiroService, IClienteServiceFront clienteServiceFront, IMovimentacaoService movimentacaoService)
        {
            _produtoFinanceiroService = produtoFinanceiroService;
            _clienteServiceFront = clienteServiceFront;
            _movimentacaoService = movimentacaoService;
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

        [HttpPost]
        public async Task<IActionResult> AplicaProduto(MovimentacaoProdutoViewModel movimentacaoProdutoView, int Id)
        {
            ModelState.Remove("ProdutoFinanceiroViewModel.NomeCliente");

            try
            {
                if (ModelState.IsValid)
                {

                    HistoricoMovimentacao historico = MovimentacaoMapper.ToModel(movimentacaoProdutoView);
                    historico.ProdutoFinanceiroId = Id;
                    await _movimentacaoService.ProcessaMovimentacao(historico, TipoOperacao.APLICACAO);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(movimentacaoProdutoView);
            }

            return View(movimentacaoProdutoView);
        }
    }
}