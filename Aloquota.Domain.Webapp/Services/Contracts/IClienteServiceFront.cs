using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aliquota.Domain.Webapp.Services.Contracts
{
    public interface IClienteServiceFront
    {
        Task<SelectList> GetListaClientes();
    }
}
