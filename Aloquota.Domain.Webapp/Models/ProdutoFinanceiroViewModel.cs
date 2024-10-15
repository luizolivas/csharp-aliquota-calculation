using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Webapp.Models
{
    public class ProdutoFinanceiroViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Valor { get; set; }
        public DateTime DataAplicacao { get; set; }
        public int ClienteId { get; set; }
    }
}
