using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.ClienteService.Contract
{
    public interface IClienteService
    {
        Task AddCliente(Cliente cliente);
        Task<IEnumerable<Cliente>> GetClientes();
    }
}
