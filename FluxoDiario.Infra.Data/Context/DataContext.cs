using FluxoDiario.Infra.Data.Entities;
using FluxoDiario.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDiario.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.ApplyConfiguration(new LancamentoMapping());
            modelBuilder.ApplyConfiguration(new SaldoMapping());
        }

        public DbSet<Lancamento> Lancamento { get; set; }

        public DbSet<Saldo> Saldo { get; set; }
    }
}
