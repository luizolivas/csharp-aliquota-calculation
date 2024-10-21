using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Services.MovimentacaoService;
using Aliquota.Domain.Services.MovimentacaoService.Contracts;
using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Test.ServicesTest
{
    public  class TestMovimentacaoService
    {

        private Mock<IMovimentacaoRepository> _mockRepository;
        private Mock<IValidaMovimentacao> _mockValidaMovimentacao;
        private Mock<IProdutoFinanceiroService> _mockProdutoFinanceiroService;
        private Mock<ICalculoService> _mockCalculoService;
        private Mock<IProvedorDateTime> _mockProvedorDateTime;
        private MovimentacaoService _movimentacaoService;

        public TestMovimentacaoService()
        {
            _mockRepository = new Mock<IMovimentacaoRepository>();
            _mockValidaMovimentacao = new Mock<IValidaMovimentacao>();
            _mockProdutoFinanceiroService = new Mock<IProdutoFinanceiroService>();
            _mockCalculoService = new Mock<ICalculoService>();
            _mockProvedorDateTime = new Mock<IProvedorDateTime>();

            _movimentacaoService = new MovimentacaoService(
                _mockRepository.Object,
                _mockValidaMovimentacao.Object,
                _mockProdutoFinanceiroService.Object,
                _mockCalculoService.Object,
                _mockProvedorDateTime.Object
            );
        }

        [Fact]
        public async Task ProcessaResgate_ValidMovimentacao_CallsExpectedMethods()
        {
            
            var movimentacao = new HistoricoMovimentacao
            {
                ProdutoFinanceiroId = 1,
                Valor = 100,
                TipoOperacao = TipoOperacao.RESGATE,
                DataOperacao = DateTime.Now
            };

            var produtoFinanceiro = new ProdutoFinanceiro
            {
                Id = 1,
                Valor = 100,
                DataAplicacao = DateTime.Now.AddDays(-30)
            };

            _mockProdutoFinanceiroService
                .Setup(p => p.GetProdutobyId(movimentacao.ProdutoFinanceiroId))
                .ReturnsAsync(produtoFinanceiro);

            _mockValidaMovimentacao
                .Setup(v => v.Valida(movimentacao, produtoFinanceiro.DataAplicacao));

            _mockCalculoService
                .Setup(c => c.CalculaLucro(produtoFinanceiro.Valor, movimentacao.Valor))
                .Returns(50); 

            _mockCalculoService
                .Setup(c => c.CalculoIR(produtoFinanceiro.DataAplicacao, movimentacao.DataOperacao, 50))
                .Returns(10); 

            await _movimentacaoService.ProcessaResgate(movimentacao);

            _mockValidaMovimentacao.Verify(v => v.Valida(movimentacao, produtoFinanceiro.DataAplicacao), Times.Once);
            _mockCalculoService.Verify(c => c.CalculaLucro(produtoFinanceiro.Valor, movimentacao.Valor), Times.Once);
            _mockCalculoService.Verify(c => c.CalculoIR(produtoFinanceiro.DataAplicacao, movimentacao.DataOperacao, 50), Times.Once);
            _mockRepository.Verify(r => r.AddMovimentacao(movimentacao), Times.Once); 
            _mockProdutoFinanceiroService.Verify(p => p.AtualizaValorProduto(movimentacao.ProdutoFinanceiroId, movimentacao.TipoOperacao, movimentacao.Valor), Times.Once);
        }

    }
}
