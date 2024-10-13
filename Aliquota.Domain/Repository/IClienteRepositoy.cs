using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repository
{
    public interface IClienteRepositoy
    {
        Task<IEnumerable<Cliente>> GetClienteAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task AddClienteAsync(Cliente cliente);
        Task SaveChangesAsync();
    }
}
