using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aliquota.Domain.Services.ProdutoFinanceiroService.Contract
{
    public interface IProdutoFinanceiroService
    {
        Task AddProduto(ProdutoFinanceiro produto);
        Task<IEnumerable<ProdutoFinanceiro>> GetProdutos();
        Task<ProdutoFinanceiro> GetProdutobyId(int id);
        Task UpdateProduto(ProdutoFinanceiro produto);
        Task DeleteProduto(int id);
        Task AtualizaValorProduto(int idProduto, TipoOperacao tipoOperacao, decimal novoValor);

    }
}
