namespace FluxoDiario.Api.Models
{
    public class LancamentoResponseModel
    {        
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }

    }
}
