using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Webapp.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Webapp.Repository
{
    public class ProdutoFinanceiroRepository : IProdutoFinaneiroRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoFinanceiroRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddProdutoFinanceiroAsync(ProdutoFinanceiro produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public async Task<ProdutoFinanceiro> GetProdutoFinanceiroByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<List<ProdutoFinanceiro>> GetProdutosFinanceirosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
