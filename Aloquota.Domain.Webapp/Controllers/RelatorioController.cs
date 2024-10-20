using Aliquota.Domain.Models;
using Aliquota.Domain.Services.MovimentacaoService.Contracts;
using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using Aliquota.Domain.Webapp.Mappers;
using Aliquota.Domain.Webapp.Models;
using Aliquota.Domain.Webapp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Domain.Webapp.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly IProdutoFinanceiroService _produtoFinanceiroService;
        private readonly IMovimentacaoService _movimentacaoService;

        public RelatorioController(IProdutoFinanceiroService produtoFinanceiroService, IMovimentacaoService movimentacaoService)
        {
            _produtoFinanceiroService = produtoFinanceiroService;
            _movimentacaoService = movimentacaoService;
        }

        public async Task<ActionResult<IEnumerable<MovimentacaoProdutoViewModel>>> Index()
        {
            var result = await _movimentacaoService.BuscaMovimentacoes();

            if (result is null)
            {
                return null;
            }

            var model = MovimentacaoMapper.ToViewModel(result);

            return View(model);
        }
    }
}
