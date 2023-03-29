using FluxoDiario.Api.Contracts;
using FluxoDiario.Api.Models;
using FluxoDiario.Infra.Data.Contracts;
using FluxoDiario.Infra.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDiario.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentosController : ControllerBase
    {
        private readonly ILogger<LancamentosController> _logger;
        private readonly ILancamentoService _lancamentoService;

        public LancamentosController(ILogger<LancamentosController> logger, ILancamentoService lancamentoService)
        {
            _logger = logger;
            _lancamentoService = lancamentoService;
        }

        [HttpGet("GetAll")]       
        [ProducesResponseType(200, Type = typeof(List<Lancamento>))]
        public IActionResult GetAll()
        {
            return Ok(_lancamentoService.GetAll());
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(200, Type = typeof(Lancamento))]
        public IActionResult GetByID(int id)
        {
            return Ok(_lancamentoService.GetById(id));
        }

        [HttpPost("Credito")]       
        public IActionResult Credito(LancamentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_lancamentoService.Credito(model));
        }
        [HttpPost("Debito")]
        public IActionResult Debito(LancamentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_lancamentoService.Debito(model));
        }
    } 
}