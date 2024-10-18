using Aliquota.Domain.Models;
using Aliquota.Domain.Services.MovimentacaoService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.MovimentacaoService
{
    public class ValidaMovimentacao : IValidaMovimentacao
    {

        public void Valida(HistoricoMovimentacao historico, DateTime d)
        {
            if(historico == null)
            {
                throw new Exception("Ocorreu um erro");
            }
            if(historico.TipoOperacao == TipoOperacao.APLICACAO)
            {
                ValidaData(DateTime.Now, d);
            }
            else
            {
                ValidaData(historico.DataOperacao, d);
            }
            
            ValidaValor(historico.Valor);

        }
         
        public void ValidaData(DateTime dataNova, DateTime dataInicial)
        {
            if (dataNova < dataInicial)
            {
                throw new Exception("A data não pode ser no passado.");
            }
        }

        public void ValidaValor(decimal valor)
        {
            if (valor <= 0)
            {
                throw new Exception("O valor deve ser maior que zero.");
            }
        }
    }
}
