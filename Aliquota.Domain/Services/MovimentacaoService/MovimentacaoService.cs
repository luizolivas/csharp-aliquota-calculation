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


        private decimal ValorCalculadoIR;

        public MovimentacaoService(IMovimentacaoRepository repository, IValidaMovimentacao validaMovimentacao, IProdutoFinanceiroService produtoFinanceiroService, ICalculoService calculoService)
        {
            _repository = repository;
            _validaMovimentacao = validaMovimentacao;
            _produtoFinanceiroService = produtoFinanceiroService;
            _calculoService = calculoService;
        }

        public async Task ProcessaMovimentacao(HistoricoMovimentacao movimentacao)
        {
            ProdutoFinanceiro prod = await _produtoFinanceiroService.GetProdutobyId(movimentacao.ProdutoFinanceiroId);
            DateTime dtAplicacao = prod.DataAplicacao;
            _validaMovimentacao.Valida(movimentacao, dtAplicacao);
            
            if(movimentacao.TipoOperacao == TipoOperacao.APLICACAO)
            {
                ValorCalculadoIR = movimentacao.Valor;
                await AplicaProduto(movimentacao);
                await AtualizaValor(movimentacao.ProdutoFinanceiroId, movimentacao.TipoOperacao, ValorCalculadoIR);
            }
            else
            {
                movimentacao.Lucro = _calculoService.CalculaLucro(prod.Valor, movimentacao.Valor);
                ValorCalculadoIR = _calculoService.CalculoIR(dtAplicacao, movimentacao.DataOperacao, movimentacao.Lucro);
                movimentacao.ValorImposto = ValorCalculadoIR;
                await ResgataProduto(movimentacao);
                await AtualizaValor(movimentacao.ProdutoFinanceiroId, movimentacao.TipoOperacao, movimentacao.Valor);
                
            }
            
        }

        public async Task AplicaProduto(HistoricoMovimentacao movimentacao)
        {
            movimentacao.DataOperacao = DateTime.Now;
            await _repository.AddMovimentacao(movimentacao);
        }

        public async Task ResgataProduto(HistoricoMovimentacao movimentacao)
        {
            await _repository.AddMovimentacao(movimentacao);
        }

        public async Task AtualizaValor(int idProduto, TipoOperacao tipoOperacao, decimal novoValor)
        {
            await _produtoFinanceiroService.AtualizaValorProduto(idProduto, tipoOperacao, novoValor);
        }

        public async Task<IEnumerable<HistoricoMovimentacao>> BuscaMovimentacoes()
        {
            return await _repository.GetMovimentacoes();
        }
    }
}
