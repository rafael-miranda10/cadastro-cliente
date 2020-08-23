using CRMALL.Domain.Dto;
using CRMALL.Domain.Entidades;
using CRMALL.Domain.Interfaces.Repositorios;
using CRMALL.Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMALL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : MainController
    {
        private readonly IClienteService _clienteService;
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteService clienteService, IClienteRepositorio clienteRepositorio)
        {
            _clienteService = clienteService;
            _clienteRepositorio = clienteRepositorio;
        }

        [Route("Adicionar")]
        [HttpPost]
        public ActionResult Adicionar(ClienteDto dto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                var resultado = _clienteService.Adicionar(dto);
                if (resultado.Notifications.Any()) return CustomResponse(resultado.Notifications);
                return CustomResponse(ClienteDto.ConverterParaDto(resultado));
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("Atualizar")]
        [HttpPut]
        public ActionResult Atualizar(ClienteDto dto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                var resultado = _clienteService.Alterar(dto);
                if (resultado.Notifications.Any()) return CustomResponse(resultado.Notifications);
                return CustomResponse(ClienteDto.ConverterParaDto(resultado));
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("Remover")]
        [HttpDelete]
        public ActionResult Remover(int id)
        {
            try
            {
                var cliente = _clienteRepositorio.ObterPorId(id);
                if (cliente == null)
                {
                    AdicionarErroProcessamento("Não foi possível localizar o cliente pelo id informado.");
                    return CustomResponse();
                }

                _clienteService.Remover(id);
                return CustomResponse();
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("ObterTodos")]
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> ObterTodos()
        {
            try
            {
                var resultados = _clienteRepositorio.ObterTodosClientes();
                return CustomResponse(resultados.Select(x => ClienteDto.ConverterParaDto(x)));
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("ObterPorId")]
        [HttpGet]
        public ActionResult<Cliente> ObterPorId(int id)
        {
            try
            {
                var resultado = _clienteRepositorio.ObterPorId(id);
                if (resultado == null) return CustomResponse();

                return CustomResponse(ClienteDto.ConverterParaDto(resultado));
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }


    }
}
