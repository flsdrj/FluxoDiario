using FluxoDiario.Api.Models;
using FluxoDiario.Infra.Data.Entities;

namespace FluxoDiario.Api.Contracts
{
    public interface ILancamentoService
    {
        List<LancamentoResponseModel> GetAll();
        Lancamento GetById(int id);
        bool Credito(LancamentoModel model);
        bool Debito(LancamentoModel model);

    }
}
