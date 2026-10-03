using System;
using System.Collections.Generic;
using System.Text;
using TechStore.Produtos.Application.DTOs;
using TechStore.Produtos.Domain.Entities;
using TechStore.Produtos.Domain.Repositories;

namespace TechStore.Produtos.Application.Services
{
    public class ProdutoDigitalService
    {
        private readonly IProdutoDigitalRepository _produtoDigitalRepository;

        public ProdutoDigitalService(IProdutoDigitalRepository produtoRepository)
        {
            _produtoDigitalRepository = produtoRepository;
        }

        public async Task CreateProdutoAsync(ProdutoRequest produtoRequest)
        {
            var produto = new ProdutoDigital(
                produtoRequest.Nome,
                produtoRequest.Categoria,
                produtoRequest.Preco,
                produtoRequest.Descricao
                );

            await _produtoDigitalRepository.CriarProduto(produto);
        }

        public async Task<ProdutoResponse> GetProdutoAsync(Guid id)
        {
            var produto = await _produtoDigitalRepository.GetProdutoById(id);

            ProdutoResponse produtoResponse = new ProdutoResponse(
                produto.Id,
                produto.Nome,
                produto.Categoria,
                produto.Preco,
                produto.Descricao
                );

            return produtoResponse;
        }

        public async Task<IEnumerable<ProdutoResponse>> ListProdutosAsync()
        {
            var produtos = await _produtoDigitalRepository.GetTodosProdutos();
            return produtos.Select(p => new ProdutoResponse(
                p.Id,
                p.Nome,
                p.Categoria,
                p.Preco,
                p.Descricao
            ));
        }

        public async Task UpdateProdutoAsync(Guid id, ProdutoRequest produtoRequest)
        {
            var produto = await _produtoDigitalRepository.GetProdutoById(id);
            produto.Nome = produtoRequest.Nome;
            produto.Categoria = produtoRequest.Categoria;
            produto.Preco = produtoRequest.Preco;
            produto.Descricao = produtoRequest.Descricao;
            await _produtoDigitalRepository.UpdateProduto(produto);
        }

        public async Task DeleteProdutoAsync(Guid id)
        {

            await _produtoDigitalRepository.DeleteProduto(id);
        }

    }
}
