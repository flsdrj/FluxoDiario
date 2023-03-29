using FluxoDiario.Infra.Data.Context;
using FluxoDiario.Infra.Data.Contracts;
using FluxoDiario.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDiario.Infra.Data.Repositories
{
    public class LancamentoRepository : BaseRepository<Lancamento>, ILancamentoRepository
    {
        private readonly DataContext dataContext;

        public LancamentoRepository(DataContext dataContext) 
            :base(dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
