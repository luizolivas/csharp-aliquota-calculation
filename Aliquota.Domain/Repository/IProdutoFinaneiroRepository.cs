using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliquota.Domain;
using Aliquota.Domain.Models;

namespace Aliquota.Domain.Repository
{
    public interface IProdutoFinaneiroRepository
    {
        Task<IEnumerable<ProdutoFinanceiro>> GetProdutosFinanceirosAsync();
        Task<ProdutoFinanceiro> GetProdutoFinanceiroByIdAsync(int id);
        Task AddProdutoFinanceiroAsync(ProdutoFinanceiro produto);
        Task UpdateProdutoFinanceiroAsync(ProdutoFinanceiro produto);
        Task DeleteProdutoFinanceiroAsync(int id);
        Task SaveChangesAsync();
    }
}
