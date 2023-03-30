using FluxoDiario.Api.Models;

namespace FluxoDiario.Api.Contracts
{
    public interface IRelatorioService
    {
        RelatorioSaldoDiaResponse GetRetatorioSaldodoDia(DateTime data);
    }
}
