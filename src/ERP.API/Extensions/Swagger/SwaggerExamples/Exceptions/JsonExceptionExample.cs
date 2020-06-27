using ERP.Domain.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ERP.API.Extensions.Swagger.SwaggerExamples.Exceptions
{
    /// <summary>
    /// Json400BadRequestExceptionExample
    /// </summary>
    public class JsonExceptionExample : IExamplesProvider<RespContainer<JsonException>>
    {
        /// <summary>
        /// GetExamples
        /// </summary>
        /// <returns></returns>
        public RespContainer<JsonException> GetExamples()
        {
            JsonException exception = new JsonException
            {
                EventId = 400
            };
            exception.DetailedMessages.Add("Username or Password is wrong");
            return RespContainer.Fail(exception, "Credentials not sufficient");
        }
    }
}
