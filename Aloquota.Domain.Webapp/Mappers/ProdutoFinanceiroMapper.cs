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
                DataAplicacao = produto.DataAplicacao,
                NomeCliente = produto.Cliente.Nome
            };
        }

        public static IEnumerable<ProdutoFinanceiroViewModel> ToViewModel(IEnumerable<ProdutoFinanceiro> produtos)
        {
            return produtos.Select(ToViewModel);
        }

        public static ProdutoFinanceiro ToModel(ProdutoFinanceiroViewModel viewModel)
        {
            return new ProdutoFinanceiro
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Valor = viewModel.Valor,
                ClienteId = viewModel.ClienteId,
                
            };
        }
    }
}
