using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.ProdutoFinanceiroService
{
    internal class GerenciaDataService : IGerenciaDatasService
    {
        public DateTime RetornaDataHoje()
        {
            DateTime thisDay = DateTime.Today;
            return thisDay;
        }
    }
}
