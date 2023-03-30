using FluxoDiario.Api.Contracts;
using FluxoDiario.Api.Models;
using FluxoDiario.Infra.Data.Contracts;
using FluxoDiario.Infra.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.OpenApi.Extensions;
using System.Collections.Generic;

namespace FluxoDiario.Api.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly ILogger<LancamentoService> _logger;
        public LancamentoService(ILancamentoRepository lancamentoRepository, ILogger<LancamentoService> logger)
        {
            _lancamentoRepository = lancamentoRepository;
            _logger = logger;
        }

        public LancamentoResponseModel GetById(int id)
        {
            var result = _lancamentoRepository.ObterPorId(id);

            return new LancamentoResponseModel()
            {
                Id = result.Id,
                Descricao = result.Descricao,
                Data = result.Data,
                Tipo = (!result.Tipo ? TipoLancamento.Debito : TipoLancamento.Credito).GetDisplayName(),
                Valor = result.Valor
            };

        }

        public List<LancamentoResponseModel> GetAll()
        {
            try
            {
                var consulta = _lancamentoRepository.Consultar();
                var result = new List<LancamentoResponseModel>();

                foreach (var item in consulta)
                {
                    result.Add(new LancamentoResponseModel()
                    {
                        Id = item.Id,
                        Data = item.Data,
                        Descricao = item.Descricao,
                        Tipo = (!item.Tipo ? TipoLancamento.Debito : TipoLancamento.Credito).GetDisplayName(),
                        Valor = item.Valor
                    });
                }

                return result;


            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new List<LancamentoResponseModel>();
            }

        }

        public bool Credito(LancamentoModel model)
        {
            try
            {
                var lancamento = new Lancamento()
                {
                    Data = DateTime.Now.Date,
                    Descricao = model.Descricao,
                    Tipo = Convert.ToBoolean((int)TipoLancamento.Credito),
                    Valor = model.Valor
                };

                _lancamentoRepository.Inserir(lancamento);
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }

        public bool Debito(LancamentoModel model)
        {
            try
            {
                var lancamento = new Lancamento()
                {
                    Data = DateTime.Now.Date,
                    Descricao = model.Descricao,
                    Tipo = Convert.ToBoolean((int)TipoLancamento.Debito),
                    Valor = model.Valor
                };

                _lancamentoRepository.Inserir(lancamento);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool Delete(int id)
        {
            var result = _lancamentoRepository.ObterPorId(id);

            if (result != null)
            {
                _lancamentoRepository.Excluir(result);
                return true;
            }

            return false;
        }
    }
}
