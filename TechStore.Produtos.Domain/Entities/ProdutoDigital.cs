using System;
using System.Collections.Generic;
using System.Text;

namespace TechStore.Produtos.Domain.Entities
{
    public class ProdutoDigital
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }

        public ProdutoDigital(string nome, string categoria, double preco, string descricao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            Descricao = descricao;
        }
    }
}
