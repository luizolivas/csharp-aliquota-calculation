using Aliquota.Domain.Models;
using Aliquota.Domain.Webapp.Models;

namespace Aliquota.Domain.Webapp.Mappers
{
    public class MovimentacaoMapper
    {
        public static HistoricoMovimentacao ToModel(MovimentacaoProdutoViewModel viewModel)
        {
            return new HistoricoMovimentacao
            {
                Valor = viewModel.Valor,
                ProdutoFinanceiroId = viewModel.ProdutoFinanceiroId,
                DataOperacao = viewModel.DataOperacao

            };
        }

        public static MovimentacaoProdutoViewModel ToViewModel(HistoricoMovimentacao movimentacao)
        {
            return new MovimentacaoProdutoViewModel
            {
                DataOperacao = movimentacao.DataOperacao,
                Valor = movimentacao.Valor,
                TipoOperacao = movimentacao.TipoOperacao,
                ProdutoFinanceiroId = movimentacao.ProdutoFinanceiroId,
                ProdutoFinanceiroViewModel = ProdutoFinanceiroMapper.ToViewModel(movimentacao.ProdutoFinanceiro),
                Lucro = movimentacao.Lucro,
                ValorImposto = movimentacao.ValorImposto
            };
        }

        public static IEnumerable<MovimentacaoProdutoViewModel> ToViewModel(IEnumerable<HistoricoMovimentacao> movimentacoes)
        {
            return movimentacoes.Select(ToViewModel);
        }
    }
}
