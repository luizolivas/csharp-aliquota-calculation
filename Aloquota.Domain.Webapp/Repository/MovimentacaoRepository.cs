using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Webapp.Context;

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
    }
}
