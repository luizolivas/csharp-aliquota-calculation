using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.MovimentacaoService.Contracts
{
    public interface ICalculoService
    {
        public decimal CalculoIR(DateTime dataAplicacao, DateTime dataResgate, decimal valor);
        public decimal CalculaLucro(decimal valorAplicacao, decimal valorResgate);
    }
}
