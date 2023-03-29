using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FluxoDiario.Api.Models
{
    public class LancamentoModel
    {      

        [Required(ErrorMessage = "Informe a descrição.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o valor.")]
        public decimal  Valor { get; set; }
        
    }

    public enum TipoLancamento
    {
        [Description("Debito")]
        Debito = 0,
        [Description("Credito")]
        Credito = 1
    }
}
