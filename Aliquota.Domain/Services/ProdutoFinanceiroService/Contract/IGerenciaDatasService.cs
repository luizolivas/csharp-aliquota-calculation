using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.ProdutoFinanceiroService.Contract
{
    public interface IGerenciaDatasService
    {
        public DateTime RetornaDataHoje();
    }
}
