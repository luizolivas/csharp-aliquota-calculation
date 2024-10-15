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
            await _context.ProdutoFinanceiro.AddAsync(produto);
        }

        public async Task<ProdutoFinanceiro> GetProdutoFinanceiroByIdAsync(int id)
        {
            return await _context.ProdutoFinanceiro.Include(p => p.Cliente).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProdutoFinanceiro>> GetProdutosFinanceirosAsync()
        {
            return await _context.ProdutoFinanceiro.Include(p => p.Cliente).ToListAsync();
        }

        public async Task UpdateProdutoFinanceiroAsync(ProdutoFinanceiro produto)
        {
            ProdutoFinanceiro prod = await GetProdutoFinanceiroByIdAsync(produto.Id);
            if(prod == null)
            {
                throw new Exception("Erro ao atualizar");
            }
            prod.Nome = produto.Nome;
            prod.Valor = produto.Valor;
            prod.DataAplicacao = produto.DataAplicacao;

        }

        public async Task DeleteProdutoFinanceiroAsync(int id)
        {
                ProdutoFinanceiro prod = await _context.ProdutoFinanceiro.FindAsync(id);
                _context.ProdutoFinanceiro.Remove(prod);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
