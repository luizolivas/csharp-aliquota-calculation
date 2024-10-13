using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Webapp.Models
{
    public class ClienteViewModel
    {

        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
