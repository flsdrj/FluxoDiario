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
    public class SaldoMapping : IEntityTypeConfiguration<Saldo>
    {
        public void Configure(EntityTypeBuilder<Saldo> builder)
        {
            builder.ToTable("Saldo");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("Id");            

            builder.Property(t => t.Data)
                .HasColumnName("Data")
                .IsRequired();

            builder.Property(t => t.Valor)
                .HasColumnName("Valor")
                .IsRequired();
           
        }
    }
}
