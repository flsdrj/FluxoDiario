using FluxoDiario.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDiario.Infra.Data.Mappings
{
    public class LancamentoMapping : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("Lancamento");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("Id");

            builder.Property(t => t.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Data)
                .HasColumnName("Data")
                .IsRequired();

            builder.Property(t => t.Valor)
                .HasColumnName("Valor")
                .IsRequired();

            builder.Property(t => t.Tipo)
                .HasColumnName("tipo")
                .IsRequired();
        }
    }
}
