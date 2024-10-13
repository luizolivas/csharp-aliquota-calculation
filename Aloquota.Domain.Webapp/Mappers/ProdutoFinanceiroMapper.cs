using Aliquota.Domain.Models;
using Aliquota.Domain.Webapp.Models;

namespace Aliquota.Domain.Webapp.Mappers
{
    public class ProdutoFinanceiroMapper
    {
        public static ProdutoFinanceiroViewModel ToViewModel(ProdutoFinanceiro produto)
        {
            return new ProdutoFinanceiroViewModel
            {
                Id = produto.Id, 
                Nome = produto.Nome,
                Valor = produto.Valor,
                DataAplicacao = produto.DataAplicacao
            };
        }

        public static IEnumerable<ProdutoFinanceiroViewModel> ToViewModel(IEnumerable<ProdutoFinanceiro> produtos)
        {
            return produtos.Select(ToViewModel);
        }
    }
}
