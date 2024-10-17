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

        public MovimentacaoService(IMovimentacaoRepository repository, IValidaMovimentacao validaMovimentacao, IProdutoFinanceiroService produtoFinanceiroService)
        {
            _repository = repository;
            _validaMovimentacao = validaMovimentacao;
            _produtoFinanceiroService = produtoFinanceiroService;
        }

        public async Task ProcessaMovimentacao(HistoricoMovimentacao movimentacao, TipoOperacao tipoOperacao)
        {
            ProdutoFinanceiro prod = await _produtoFinanceiroService.GetProdutobyId(movimentacao.ProdutoFinanceiroId);
            DateTime dt = prod.DataAplicacao;
            movimentacao.DataOperacao = DateTime.Now;
            _validaMovimentacao.Valida(movimentacao,dt);
            
            if(tipoOperacao == TipoOperacao.APLICACAO)
            {
                await AplicaProduto(movimentacao);
            }
            else
            {
                await ResgataProduto(movimentacao);
            }
            await AtualizaValor(movimentacao.ProdutoFinanceiroId, movimentacao.Valor);
        }

        public async Task AplicaProduto(HistoricoMovimentacao movimentacao)
        {
            await _repository.AddMovimentacao(movimentacao);
        }

        public async Task ResgataProduto(HistoricoMovimentacao movimentacao)
        {
            await _repository.AddMovimentacao(movimentacao);
        }

        public async Task AtualizaValor(int idProduto, decimal novoValor)
        {
            await _produtoFinanceiroService.AtualizaValorProduto(idProduto, novoValor);
        }
    }
}
