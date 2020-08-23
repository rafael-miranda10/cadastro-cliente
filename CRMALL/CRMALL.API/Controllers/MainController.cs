using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;

namespace CRMALL.API.Controllers
{
    [ApiController]
    public class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperationIsValid())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }

        protected ActionResult CustomExceptionResponse()
        {
            dynamic resposnseException = new ExpandoObject();
            resposnseException.Status = HttpStatusCode.InternalServerError;
            resposnseException.Errors = new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            };

            return StatusCode(StatusCodes.Status500InternalServerError, resposnseException);
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(IReadOnlyCollection<Notification> notifications)
        {
            foreach (var erro in notifications)
            {
                AdicionarErroProcessamento(erro.Message);
            }

            return CustomResponse();
        }

        protected bool OperationIsValid()
        {
            return !Erros.Any();
        }

        protected void AdicionarErroProcessamento(string erro)
        {
            Erros.Add(erro);
        }

        protected void LimparErrosProcessamento()
        {
            Erros.Clear();
        }

        protected void MessageException()
        {
            AdicionarErroProcessamento("Ops! Algo não deu certo. Aguarde um instante e tente novamente, caso o erro persista entre em contato com o administrador do sistema.");
        }
    }
}
