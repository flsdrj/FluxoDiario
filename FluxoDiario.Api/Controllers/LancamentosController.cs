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
        [ProducesResponseType(200, Type = typeof(List<LancamentoResponseModel>))]
        public IActionResult GetAll()
        {
            _logger.LogInformation("GetAll - iniciado");

            return Ok(_lancamentoService.GetAll());
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(200, Type = typeof(LancamentoResponseModel))]
        public IActionResult GetByID(int id)
        {
            _logger.LogInformation("GetByID - iniciado");

            return Ok(_lancamentoService.GetById(id));
        }

        [HttpPost("Credito")]
        public IActionResult Credito(LancamentoModel model)
        {
            _logger.LogInformation("Credito - iniciado");

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_lancamentoService.Credito(model))
                return BadRequest();

            return Ok("Credito Registrado");
        }

        [HttpPost("Debito")]
        public IActionResult Debito(LancamentoModel model)
        {
            _logger.LogInformation("Debito - iniciado");

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_lancamentoService.Debito(model))
                return BadRequest();

            return Ok("Debito Registrado");
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete - iniciado");

            if (!_lancamentoService.Delete(id))
            {
                return BadRequest("Objeto inexistente");
            }

            return Ok("Deleção ok");
        }
    }
}