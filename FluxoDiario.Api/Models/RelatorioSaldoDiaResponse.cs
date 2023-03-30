namespace FluxoDiario.Api.Models
{
    public class RelatorioSaldoDiaResponse
    {
        public int TotalOperacoes { get; set; }
        public int NumDebitos { get; set; }
        public int NumCreditos { get; set;}
        public float ValortotalDebitos { get; set; }
        public float ValortotalCreditos { get; set; }
        public float SaldoDoDia { get; set; }

    }
}
