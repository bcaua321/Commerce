using Commerce.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Commerce.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is CommerceException)
            {
                TreatCommerceException(context);
                return;
            }

            TreatOtherException(context);
        }

        private void TreatCommerceException(ExceptionContext context)
        {
            if(context.Exception is CommerceValidationException)
            {
                TreatValidationException(context);
            }
        }

        private void TreatValidationException(ExceptionContext context)
        {
            var errorsDeValidacaoExceptions = context.Exception as CommerceValidationException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(errorsDeValidacaoExceptions.Messages);
        }

        private void TreatOtherException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult("Erro Interno");
        }
    }
}
