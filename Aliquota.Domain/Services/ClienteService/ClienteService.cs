using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Services.ClienteService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.ClienteService
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositoy _clienteRepository;

        public ClienteService(IClienteRepositoy clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task AddCliente(Cliente cliente)
        {
            await _clienteRepository.AddClienteAsync(cliente);
            await _clienteRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _clienteRepository.GetClienteAsync();
        }
    }
}
