using CRMALL.Domain.Dto;
using CRMALL.Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRMALL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaCepController : MainController
    {
        private readonly IConsultaCepService _consultaCepService;

        public ConsultaCepController(IConsultaCepService consultaCepService)
        {
            _consultaCepService = consultaCepService;
        }

        [Route("ConsultarCep")]
        [HttpGet]
        public ActionResult<ViaCepDto> ConsultarCep(string cep)
        {
            try
            {
                var resultado = _consultaCepService.Consultar(cep);
                if (resultado == null) return CustomResponse();

                return CustomResponse(resultado);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }
    }
}
