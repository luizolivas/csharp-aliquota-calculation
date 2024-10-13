using Aliquota.Domain.Models;
using Aliquota.Domain.Webapp.Models;

namespace Aliquota.Domain.Webapp.Mappers
{
    public class ClienteMapper
    {
        public static ClienteViewModel ToViewModel(Cliente produto)
        {
            return new ClienteViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome
            };
        }

        public static IEnumerable<ClienteViewModel> ToViewModel(IEnumerable<Cliente> clientes)
        {
            return clientes.Select(ToViewModel);
        }
    }
}
