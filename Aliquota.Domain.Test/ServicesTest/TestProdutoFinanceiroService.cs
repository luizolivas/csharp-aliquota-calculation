using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using Aliquota.Domain.Webapp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;
using Moq;
using Aliquota.Domain.Services.ProdutoFinanceiroService;


namespace Aliquota.Domain.Test.ServicesTest
{
    public class TestProdutoFinanceiroService
    {
        private IProdutoFinanceiroService _produtoFinanceiroService;
        private IProdutoFinaneiroRepository _produtoFinaneiroRepository;
        private ApplicationDbContext _context;

        public TestProdutoFinanceiroService()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);

            var mockRepository = new Mock<IProdutoFinaneiroRepository>();

            mockRepository.Setup(repo => repo.AddProdutoFinanceiroAsync(It.IsAny<ProdutoFinanceiro>()))
                .Callback<ProdutoFinanceiro>(prod => _context.ProdutoFinanceiro.Add(prod));

            var produtoFinaneiroRepository = mockRepository.Object;

            _produtoFinanceiroService = new ProdutoFinanceiroService(produtoFinaneiroRepository);
        }

        [Fact]
        public async Task Post_CreateProdutoFinanceiro()
        {
            DateTime dtHj = DateTime.Now;
            ProdutoFinanceiro prod = new ProdutoFinanceiro { Nome = "teste", Valor = 10, DataAplicacao = dtHj };

            await _produtoFinanceiroService.AddProduto(prod);

            ProdutoFinanceiro result = await _context.ProdutoFinanceiro.FindAsync(1);

            Assert.NotNull(result);
            Assert.Equal(prod.Nome, result.Nome);
            Assert.Equal(prod.Valor, result.Valor);
            Assert.Equal(prod.DataAplicacao, result.DataAplicacao);

            _context.Database.EnsureDeleted(); 
        }
    }
}
