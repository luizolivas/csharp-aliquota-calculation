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
            };
        }
    }
}
