using System;
using System.Collections.Generic;
using System.Text;
using TechStore.Produtos.Domain.Entities;

namespace TechStore.Produtos.Domain.Repositories
{
    public interface IProdutoDigitalRepository
    {
        Task CriarProduto(ProdutoDigital produto);
        Task<ProdutoDigital> GetProdutoById(Guid id);
        Task<IEnumerable<ProdutoDigital>> GetTodosProdutos();
        Task UpdateProduto(ProdutoDigital produto);
        Task DeleteProduto(Guid id);
    }
}
