using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Webapp.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Webapp.Repository
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public MovimentacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMovimentacao(HistoricoMovimentacao movimentacao)
        {
            await _context.HistoricoMovimentacao.AddAsync(movimentacao);
        }
        
        public async Task<IEnumerable<HistoricoMovimentacao>> GetMovimentacoes()
        {
            return  await _context.HistoricoMovimentacao.Include(h => h.ProdutoFinanceiro).Include(c => c.ProdutoFinanceiro.Cliente).ToListAsync();
        }
    }
}
