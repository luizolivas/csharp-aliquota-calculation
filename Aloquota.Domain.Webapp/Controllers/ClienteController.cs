using Aliquota.Domain.Models;
using Aliquota.Domain.Services.ClienteService.Contract;
using Aliquota.Domain.Webapp.Mappers;
using Aliquota.Domain.Webapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Domain.Webapp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<ActionResult<IEnumerable<Cliente>>> Index()
        {
            var result = await _clienteService.GetClientes();
            if (result == null)
            {
                return View("Error");
            }

            var viewModel = ClienteMapper.ToViewModel(result);

            return View(viewModel);
        }

        public async Task<IActionResult> NovoCliente()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> CriaCliente(ClienteViewModel clienteVM)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente()
                {
                    Nome = clienteVM.Nome
                };

                await _clienteService.AddCliente(cliente);
                return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "Erro ao cadastrar cliente.");
            return View(clienteVM);

        }
    }
}
