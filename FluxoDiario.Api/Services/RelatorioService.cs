using FluxoDiario.Api.Contracts;
using FluxoDiario.Api.Models;
using FluxoDiario.Infra.Data.Contracts;


namespace FluxoDiario.Api.Services
{
    public class RelatorioService : IRelatorioService
    {

        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly ILogger<LancamentoService> _logger;

        public RelatorioService(ILancamentoRepository lancamentoRepository,
                                ILogger<LancamentoService> logger)
        {
            _lancamentoRepository = lancamentoRepository;
            _logger = logger;
        }

        public RelatorioSaldoDiaResponse GetRetatorioSaldodoDia(DateTime data)
        {
            var LancamentosDia = _lancamentoRepository.Consultar().Where(x => x.Data == data);
            var DebitosDia = LancamentosDia.Where(x => x.Tipo == Convert.ToBoolean((int)TipoLancamento.Debito));
            var CreditosDia = LancamentosDia.Where(x => x.Tipo == Convert.ToBoolean((int)TipoLancamento.Credito));

            var result = new RelatorioSaldoDiaResponse()
            {
                TotalOperacoes = LancamentosDia.Count(),
                NumCreditos = CreditosDia.Count(),
                NumDebitos = DebitosDia.Count(),
                ValortotalCreditos = (float)CreditosDia.Sum(x => x.Valor),
                ValortotalDebitos = (float)DebitosDia.Sum(x => x.Valor),
                SaldoDoDia = (float)CreditosDia.Sum(x => x.Valor) - (float)DebitosDia.Sum(x => x.Valor)
            };
            return result;
        }        

    }
}
