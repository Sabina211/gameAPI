using GameAPI.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameAPI.Web.Middlewares
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var exceptionStack = context.Exception.StackTrace;
            var exceptionMessage = context.Exception.Message;
            var statusCode = 400;

            switch (true)
            {
                case { } when context.Exception is EntityNotFoundException:
                    {
                        statusCode = 404;
                        break;
                    }
                case { } when context.Exception.InnerException is EntityNotFoundException:
                    {
                        statusCode = 404;
                        exceptionMessage = context.Exception.InnerException.Message;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            context.Result = new JsonResult(exceptionMessage)
            {
                StatusCode = statusCode
            };

            _logger.LogError($"В методе {actionName} возникло исключение: \n{exceptionMessage} \n {exceptionStack}\n");
        }
    }
}