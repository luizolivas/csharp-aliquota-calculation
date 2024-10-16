﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class ProdutoFinanceiro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Valor { get; set; }
        public DateTime DataAplicacao { get; set; }
        public int ClienteId { get; set; }


        public ICollection<HistoricoMovimentacao> HistoricoMovimentacoes { get; set; }
        public Cliente Cliente { get; set; }


    }
}
