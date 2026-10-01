using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TechStore.Produtos.Domain.Entities;
using TechStore.Produtos.Domain.Repositories;

namespace TechStore.Produtos.Infrastructure.Repositories
{
    public class ProdutoDigitalRepository : IProdutoDigitalRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoDigitalRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task CriarProduto(ProdutoDigital produto)
        {
            await _appDbContext.ProdutosDigitais.AddAsync(produto);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProduto(Guid id)
        {
            await Task.Run(() =>
            {
                var produto = _appDbContext.ProdutosDigitais.Find(id);

                if(produto != null)
                {
                    _appDbContext.ProdutosDigitais.Remove(produto);
                    _appDbContext.SaveChanges();
                }
            });
        }

        public async Task<ProdutoDigital> GetProdutoById(Guid id)
        {
            var produto = await _appDbContext.ProdutosDigitais.FindAsync(id);

            if(produto == null)
            {
                return null;
            } else
            {
                return produto;
            }
        }

        public async Task<IEnumerable<ProdutoDigital>> GetTodosProdutos()
        {
            return await _appDbContext.ProdutosDigitais.ToArrayAsync();
        }

        public async Task UpdateProduto(ProdutoDigital produto)
        {
            await Task.Run(() =>
            {
                _appDbContext.ProdutosDigitais.Update(produto);
                _appDbContext.SaveChanges();
            });
        }
    }
}
