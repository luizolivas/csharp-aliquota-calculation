namespace Aliquota.Domain.Webapp.Models
{
    public class MovimentacaoProdutoViewModel
    {
        public ProdutoFinanceiroViewModel ProdutoFinanceiroViewModel { get; set; }
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataOperacao { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
        public int ProdutoFinanceiroId { get; set; }
    }
}
