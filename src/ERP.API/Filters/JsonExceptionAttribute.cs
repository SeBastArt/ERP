using ERP.Domain.Extensions;
using ERP.Domain.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.RegularExpressions;

namespace ERP.API.Filters
{
    public class JsonExceptionAttribute : TypeFilterAttribute
    {
        public JsonExceptionAttribute() : base(typeof
            (HttpCustomExceptionFilterImpl))
        {
        }

        private class HttpCustomExceptionFilterImpl : IExceptionFilter
        {
            private readonly IWebHostEnvironment _env;
            private readonly ILogger<HttpCustomExceptionFilterImpl> _logger;

            public HttpCustomExceptionFilterImpl(IWebHostEnvironment env,
                ILogger<HttpCustomExceptionFilterImpl> logger)
            {
                _env = env;
                _logger = logger;
            }

            public void OnException(ExceptionContext context)
            {
                int statusCode = -1;
                EventId eventId = new EventId(context.Exception.HResult);

                _logger.LogError(eventId,
                    context.Exception,
                    context.Exception.Message);

                switch (context.Exception.GetType().Name)
                {
                    case "StackException":
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case "NotFoundException":
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                RespContainer<JsonException> container = RespContainer.Fail(new JsonException { EventId = statusCode }, Regex.Unescape(context.Exception.Message));
                if (context.Exception is StackException we && (we.Errors.Count > 0))
                {
                    container.Data.DetailedMessages = we.Errors;
                }
                else
                {
                    container.Data.DetailedMessages.Add(Regex.Unescape(context.Exception.Message));
                }

                ObjectResult exceptionObject = new ObjectResult(container) { StatusCode = statusCode };
                context.Result = exceptionObject;
                context.HttpContext.Response.StatusCode = statusCode;
            }
        }
    }
}