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
        public string ImagemProdutoURL { get; set; }
        public string Status { get; set; }
    }
}
