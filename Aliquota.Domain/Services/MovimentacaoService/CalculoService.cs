using Aliquota.Domain.Services.MovimentacaoService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.MovimentacaoService
{
    public class CalculoService : ICalculoService
    {
        public decimal CalculoIR(DateTime dataAplicacao, DateTime dataResgate, decimal lucro)
        {
            TimeSpan data = dataResgate - dataAplicacao;
            decimal porcentagemImposto = 0;

            int dias = data.Days;

            if (dias <= 365)
            {
                porcentagemImposto = 0.225m;
            }
            else if (dias > 365 && dias <= 730)
            {
                porcentagemImposto = 0.185m;
            }
            else
            {
                porcentagemImposto = 0.15m;
            }

            return lucro * porcentagemImposto;
        }

        public decimal CalculaLucro(decimal valorAplicacao, decimal valorResgate)
        {
            decimal lucro = valorResgate - valorAplicacao;

            if (lucro <= 0)
            {
                return 0;
            }

            return lucro;
        }
    }
}
