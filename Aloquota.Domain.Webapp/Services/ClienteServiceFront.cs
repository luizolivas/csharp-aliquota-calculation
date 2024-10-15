using Aliquota.Domain.Models;
using Aliquota.Domain.Services.ClienteService.Contract;
using Aliquota.Domain.Webapp.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aliquota.Domain.Webapp.Services
{
    public class ClienteServiceFront : IClienteServiceFront
    {
        private readonly IClienteService _clienteService;

        public ClienteServiceFront(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<SelectList> GetListaClientes()
        {
            var clientes = await _clienteService.GetClientes();
            return new SelectList(clientes, "Id", "Nome");

        }
    }
}
