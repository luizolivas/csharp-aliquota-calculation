using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Services.ClienteService;
using Aliquota.Domain.Services.ClienteService.Contract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Test.ServicesTest
{
    public class TestClienteService
    {
        private readonly Mock<IClienteRepositoy> _mockRepository;
        private readonly IClienteService _clienteService;

        public TestClienteService()
        {
            _mockRepository = new Mock<IClienteRepositoy>();

            _clienteService = new ClienteService(_mockRepository.Object);
        }

        [Fact]
        public async Task AddCliente_DeveAdicionarCliente()
        {
            var cliente = new Cliente { Nome = "Cliente Teste" };

            _mockRepository.Setup(repo => repo.AddClienteAsync(It.IsAny<Cliente>()))
                .Returns(Task.CompletedTask);

            await _clienteService.AddCliente(cliente);

            _mockRepository.Verify(repo => repo.AddClienteAsync(It.Is<Cliente>(c => c.Nome == "Cliente Teste")), Times.Once);
        }

        public async Task GetCliente_DeveRetornarClientes()
        {
            var clientes = new List<Cliente>
            {
                new Cliente { Nome = "Cliente Teste 1" },
                new Cliente { Nome = "Cliente Teste 2" },
                new Cliente { Nome = "Cliente Teste 3" }
            };

            _mockRepository.Setup(repo => repo.GetClienteAsync())
                           .ReturnsAsync(clientes); 

            var resultado = await _clienteService.GetClientes(); 

            Assert.NotNull(resultado); 
            Assert.Equal(3, resultado.Count()); 
            Assert.Equal("Cliente Teste 1", resultado.First().Nome); 
        }

        [Fact]
        public async Task GetClienteById_DeveBuscarRetornarCliente()
        {
            var clienteId = 1;
            var cliente = new Cliente { Id = clienteId, Nome = "Cliente Teste" };

            _mockRepository.Setup(repo => repo.GetClienteByIdAsync(clienteId))
                .ReturnsAsync(cliente);

            var result = await _clienteService.GetClienteById(clienteId);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Cliente Teste", result.Nome);
        }

    }
}
