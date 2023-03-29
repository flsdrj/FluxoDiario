using FluxoDiario.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDiario.Infra.Data.Contracts
{
    public interface ILancamentoRepository : IBaseRepository<Lancamento>
    {
    }
}
