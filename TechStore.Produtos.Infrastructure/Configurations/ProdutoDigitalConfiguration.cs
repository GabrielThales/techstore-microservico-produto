using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TechStore.Produtos.Domain.Entities;

namespace TechStore.Produtos.Infrastructure.Configurations
{
    internal class ProdutoDigitalConfiguration : IEntityTypeConfiguration<ProdutoDigital>
    {
        public void Configure(EntityTypeBuilder<ProdutoDigital> builder)
        {
            builder.ToTable("ProdutosDigitaisDB");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(500);    
        }
    }
}
