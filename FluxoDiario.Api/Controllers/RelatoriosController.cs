using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mime;
using FluxoDiario.Api.Contracts;
using FluxoDiario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace FluxoDiario.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly ILogger<RelatoriosController> _logger;
        private readonly IRelatorioService _relatorioService;
        public RelatoriosController(ILogger<RelatoriosController> logger, IRelatorioService relatorioService)
        {
            _logger = logger;
            _relatorioService = relatorioService;
        }
        /// <summary>
        /// RetatorioSaldodoDia
        /// </summary>
        /// <remarks>
        /// Retorna RetatorioSaldodoDia
        /// </remarks>
        /// <param name="data">Data em formato yyyy-mm-dd</param>
        [HttpGet("RetatorioSaldodoDia")]
        [ProducesResponseType(200, Type = typeof(List<RelatorioSaldoDiaResponse>))]
        public IActionResult GetRelatoriodoDia(DateTime data)
        {
            _logger.LogInformation("GetRelatoriodoDia - iniciado");

            return Ok(_relatorioService.GetRetatorioSaldodoDia(data));
        }        

    }
}
