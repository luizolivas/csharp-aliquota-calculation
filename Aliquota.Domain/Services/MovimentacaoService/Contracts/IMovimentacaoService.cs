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
        Task ProcessaMovimentacao(HistoricoMovimentacao movimentacao, TipoOperacao tipoOperacao);
        Task AplicaProduto(HistoricoMovimentacao movimentacao);
        Task ResgataProduto(HistoricoMovimentacao movimentacao);
        Task AtualizaValor(int idProduto, decimal novoValor);
    }
}
