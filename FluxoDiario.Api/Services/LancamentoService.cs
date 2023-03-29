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
        private readonly ILancamentoRepository lancamentoRepository;
        private readonly ILogger<LancamentoService> _logger;
        public LancamentoService(ILancamentoRepository lancamentoRepository = null, ILogger<LancamentoService> logger = null)
        {
            this.lancamentoRepository = lancamentoRepository;
            _logger = logger;
        }

        public Lancamento GetById(int id)
        {
            return lancamentoRepository.ObterPorId(id);
        }

        public List<LancamentoResponseModel> GetAll()
        {
            try
            {
                var consulta = lancamentoRepository.Consultar();
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

                lancamentoRepository.Inserir(lancamento);
                return true;
            }
            catch (Exception e)
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

                lancamentoRepository.Inserir(lancamento);
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }
    }
}
