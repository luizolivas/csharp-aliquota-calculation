using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;
using Moq;
using Xunit;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using Aliquota.Domain.Services.ProdutoFinanceiroService;

namespace Aliquota.Domain.Test.ServicesTest
{
    public class TestProdutoFinanceiroService
    {
        private readonly Mock<IProdutoFinaneiroRepository> _mockRepository;
        private readonly IProdutoFinanceiroService _produtoFinanceiroService;

        public TestProdutoFinanceiroService()
        {
            _mockRepository = new Mock<IProdutoFinaneiroRepository>();

            _produtoFinanceiroService = new ProdutoFinanceiroService(_mockRepository.Object);
        }

        [Fact]
        public async Task AddProdutoFinanceiro_DeveChamarAdicionaProduto()
        {
            DateTime dtHj = DateTime.Now;
            var produto = new ProdutoFinanceiro { Nome = "Teste", Valor = 100, DataAplicacao = dtHj };

            _mockRepository.Setup(repo => repo.AddProdutoFinanceiroAsync(It.IsAny<ProdutoFinanceiro>()))
                .Returns(Task.CompletedTask);

            await _produtoFinanceiroService.AddProduto(produto);

            _mockRepository.Verify(repo => repo.AddProdutoFinanceiroAsync(It.Is<ProdutoFinanceiro>(p => p.Nome == "Teste" && p.Valor == 100)), Times.Once);
        }

        [Fact]
        public async Task GetProdutoFinanceiroById_DeveRetornarProduto()
        {
            var produtoId = 1;
            var produto = new ProdutoFinanceiro { Id = produtoId, Nome = "Produto Teste", Valor = 200 };

            _mockRepository.Setup(repo => repo.GetProdutoFinanceiroByIdAsync(produtoId))
                .ReturnsAsync(produto);

            var result = await _produtoFinanceiroService.GetProdutobyId(produtoId);

            Assert.NotNull(result);
            Assert.Equal(produtoId, result.Id);
            Assert.Equal("Produto Teste", result.Nome);
            Assert.Equal(200, result.Valor);
        }

        [Fact]
        public async Task DeleteProdutoFinanceiro_DeveChamarDelete()
        {
            var produtoId = 1;

            _mockRepository.Setup(repo => repo.DeleteProdutoFinanceiroAsync(produtoId))
                .Returns(Task.CompletedTask);

            await _produtoFinanceiroService.DeleteProduto(produtoId);

            _mockRepository.Verify(repo => repo.DeleteProdutoFinanceiroAsync(produtoId), Times.Once);
        }
    }
}
