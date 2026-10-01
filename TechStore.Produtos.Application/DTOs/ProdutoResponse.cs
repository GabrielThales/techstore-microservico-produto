using System;
using System.Collections.Generic;
using System.Text;

namespace TechStore.Produtos.Application.DTOs
{
    public class ProdutoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }

        public ProdutoResponse(Guid id, string nome, string categoria, double preco, string descricao)
        {
            Id = id;
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            Descricao = descricao;
        }
    }
}
