using ERP.Domain.Requests.User;
using Swashbuckle.AspNetCore.Filters;

namespace ERP.API.Extensions.Swagger.SwaggerExamples.Requests.User
{
    /// <summary>
    /// SignInRequestExample
    /// </summary>
    public class SignInRequestExample : IExamplesProvider<SignInRequest>
    {
        /// <summary>
        /// GetExamples
        /// </summary>
        /// <returns></returns>
        public SignInRequest GetExamples()
        {
            return new SignInRequest
            {
                Email = "mail@me.de",
                Password = "password",
            };
        }
    }
}