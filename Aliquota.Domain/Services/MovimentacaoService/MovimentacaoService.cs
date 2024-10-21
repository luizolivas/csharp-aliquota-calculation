using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Services.MovimentacaoService.Contracts;
using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.MovimentacaoService
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoRepository _repository;
        private readonly IValidaMovimentacao _validaMovimentacao;
        private readonly IProdutoFinanceiroService _produtoFinanceiroService;
        private readonly ICalculoService _calculoService;
        private readonly IProvedorDateTime _provedorDateTime;

        public MovimentacaoService(IMovimentacaoRepository repository, IValidaMovimentacao validaMovimentacao, IProdutoFinanceiroService produtoFinanceiroService, ICalculoService calculoService, IProvedorDateTime provedorDateTime)
        {
            _repository = repository;
            _validaMovimentacao = validaMovimentacao;
            _produtoFinanceiroService = produtoFinanceiroService;
            _calculoService = calculoService;
            _provedorDateTime = provedorDateTime;
        }

        #region Preparação e Validações
        public async Task ProcessaResgate(HistoricoMovimentacao movimentacao)
        {
            ProdutoFinanceiro prod = await _produtoFinanceiroService.GetProdutobyId(movimentacao.ProdutoFinanceiroId);
            DateTime dtAplicacao = prod.DataAplicacao;
            ValidaMovimentacao(movimentacao, dtAplicacao);


            movimentacao.Lucro = _calculoService.CalculaLucro(prod.Valor, movimentacao.Valor);
            decimal ValorCalculadoIR = _calculoService.CalculoIR(dtAplicacao, movimentacao.DataOperacao, movimentacao.Lucro);
            movimentacao.ValorImposto = ValorCalculadoIR;

            await RegistrarResgate(movimentacao);
            await AtualizaValor(movimentacao.ProdutoFinanceiroId, movimentacao.TipoOperacao, movimentacao.Valor);
        }

        public async Task ProcessaAplicacao(HistoricoMovimentacao movimentacao)
        {
            ProdutoFinanceiro prod = await _produtoFinanceiroService.GetProdutobyId(movimentacao.ProdutoFinanceiroId);
            DateTime dtAplicacao = prod.DataAplicacao;
            ValidaMovimentacao(movimentacao, dtAplicacao);

            decimal ValorCalculadoIR = movimentacao.Valor;
            await RegistrarAplicacao(movimentacao);
            await AtualizaValor(movimentacao.ProdutoFinanceiroId, movimentacao.TipoOperacao, ValorCalculadoIR);
        }

        private void ValidaMovimentacao(HistoricoMovimentacao movimentacao, DateTime dtAplicacao)
        {
            _validaMovimentacao.Valida(movimentacao, dtAplicacao);
        }

        #endregion

        #region Execuções com banco

        public async Task<IEnumerable<HistoricoMovimentacao>> BuscaMovimentacoes()
        {
            return await _repository.GetMovimentacoes();
        }

        public async Task RegistrarAplicacao(HistoricoMovimentacao movimentacao)
        {
            movimentacao.DataOperacao = _provedorDateTime.Now;
            await _repository.AddMovimentacao(movimentacao);
        }

        public async Task RegistrarResgate(HistoricoMovimentacao movimentacao)
        {
            await _repository.AddMovimentacao(movimentacao);
        }

        public async Task AtualizaValor(int idProduto, TipoOperacao tipoOperacao, decimal novoValor)
        {
            await _produtoFinanceiroService.AtualizaValorProduto(idProduto, tipoOperacao, novoValor);
        }

        #endregion
    }
}
