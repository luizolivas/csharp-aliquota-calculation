using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Webapp.Models
{
    public class MovimentacaoProdutoViewModel
    {
        public ProdutoFinanceiroViewModel ProdutoFinanceiroViewModel { get; set; }
        public int Id { get; set; }
        public decimal Valor { get; set; }
        [Display(Name = "Data Operação")]
        public DateTime DataOperacao { get; set; }
        [Display(Name = "Tipo")]
        public TipoOperacao TipoOperacao { get; set; }
        public int ProdutoFinanceiroId { get; set; }
        public decimal ValorImposto { get; set; }
        public decimal Lucro { get; set; }
    }
}
