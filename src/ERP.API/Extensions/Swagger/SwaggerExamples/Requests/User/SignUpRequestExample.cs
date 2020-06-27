using ERP.Domain.Requests.User;
using Swashbuckle.AspNetCore.Filters;

namespace ERP.API.Extensions.Swagger.SwaggerExamples.Requests.User
{
    /// <summary>
    /// SignUpRequestExample
    /// </summary>
    public class SignUpRequestExample : IExamplesProvider<SignUpRequest>
    {
        /// <summary>
        /// GetExamples
        /// </summary>
        /// <returns></returns>
        public SignUpRequest GetExamples()
        {
            return new SignUpRequest
            {
                Email = "mail@me.de",
                Password = "password",
                FirstName = "Sebastian",
                LastName = "Schüler"
            };
        }
    }
}
