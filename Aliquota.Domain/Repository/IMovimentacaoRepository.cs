using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repository
{
    public interface IMovimentacaoRepository
    {
        Task AddMovimentacao(HistoricoMovimentacao movimentacao);
        Task<IEnumerable<HistoricoMovimentacao>> GetMovimentacoes();
    }
}
