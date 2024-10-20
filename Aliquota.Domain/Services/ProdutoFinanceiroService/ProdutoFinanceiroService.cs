using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services.ProdutoFinanceiroService
{
    public class ProdutoFinanceiroService : IProdutoFinanceiroService
    {
        private readonly IProdutoFinaneiroRepository _produtoFinaneiroRepository;

        public ProdutoFinanceiroService(IProdutoFinaneiroRepository produtoFinaneiroRepository)
        {
            _produtoFinaneiroRepository = produtoFinaneiroRepository;
        }

        public async Task AddProduto(ProdutoFinanceiro produto)
        {
            produto.DataAplicacao = DateTime.Now;
            await _produtoFinaneiroRepository.AddProdutoFinanceiroAsync(produto);
            await _produtoFinaneiroRepository.SaveChangesAsync();
        }

        public async Task<ProdutoFinanceiro> GetProdutobyId(int id)
        {
            return await _produtoFinaneiroRepository.GetProdutoFinanceiroByIdAsync(id);
        }

        public async Task<IEnumerable<ProdutoFinanceiro>> GetProdutos()
        {
            return await _produtoFinaneiroRepository.GetProdutosFinanceirosAsync();
        }

        public async Task UpdateProduto(ProdutoFinanceiro produto)
        {
            await _produtoFinaneiroRepository.UpdateProdutoFinanceiroAsync(produto);
            await _produtoFinaneiroRepository.SaveChangesAsync();
        }

        public async Task DeleteProduto(int id)
        {
            await _produtoFinaneiroRepository.DeleteProdutoFinanceiroAsync(id);
            await _produtoFinaneiroRepository.SaveChangesAsync();
        }

        public async Task AtualizaValorProduto(int idProduto, TipoOperacao tipoOperacao, decimal novoValor)
        {
            ProdutoFinanceiro prod = await GetProdutobyId(idProduto);  
            
            if(tipoOperacao == TipoOperacao.APLICACAO)
            {
                novoValor += prod.Valor;
            }
            else
            {
                novoValor = prod.Valor - novoValor;
                if(novoValor < 0) novoValor = 0;
            }

            
            await _produtoFinaneiroRepository.AtualizaValorProduto(idProduto, novoValor);
            await _produtoFinaneiroRepository.SaveChangesAsync();
        }
    }
}
