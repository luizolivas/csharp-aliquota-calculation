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
            produto.DataAplicacao = DateTime.Today;
            await _produtoFinaneiroRepository.AddProdutoFinanceiroAsync(produto);
            await _produtoFinaneiroRepository.SaveChangesAsync();
        }
    }
}
