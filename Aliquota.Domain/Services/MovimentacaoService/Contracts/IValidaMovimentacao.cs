using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.MovimentacaoService.Contracts
{
    public interface IValidaMovimentacao
    {
        public void Valida(HistoricoMovimentacao historico, DateTime dtInicial);
        public void ValidaData(DateTime dataNova, DateTime dataInicial);
        public void ValidaValor(decimal valor);
    }
}
