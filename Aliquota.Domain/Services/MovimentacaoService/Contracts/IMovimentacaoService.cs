using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.MovimentacaoService.Contracts
{
    public interface IMovimentacaoService
    {
        Task ProcessaResgate(HistoricoMovimentacao movimentacao);
        Task ProcessaAplicacao(HistoricoMovimentacao movimentacao);
        Task RegistrarAplicacao(HistoricoMovimentacao movimentacao);
        Task RegistrarResgate(HistoricoMovimentacao movimentacao);
        Task AtualizaValor(int idProduto, TipoOperacao tipoOperacao, decimal novoValor);
        Task<IEnumerable<HistoricoMovimentacao>> BuscaMovimentacoes();
    }
}
