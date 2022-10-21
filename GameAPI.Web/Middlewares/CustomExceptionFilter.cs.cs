using GameAPI.Domain.Exceptions;
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

            var statusCode = true switch
            {
                { } when context.Exception is EntityNotFoundException => 404,
                _ => 400
            };

            context.Result = new JsonResult(exceptionMessage)
            {
                StatusCode = statusCode
            };

            _logger.LogError($"В методе {actionName} возникло исключение: \n{exceptionMessage} \n {exceptionStack}\n");
        }
    }
}