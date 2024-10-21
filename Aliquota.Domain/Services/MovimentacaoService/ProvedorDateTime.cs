using Aliquota.Domain.Services.MovimentacaoService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.MovimentacaoService
{
    public class ProvedorDateTime : IProvedorDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
