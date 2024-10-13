using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class HistoricoMovimentacao
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataOperacao { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
        public int ProdutoFinanceiroId { get; set; }

        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }
    }
}
