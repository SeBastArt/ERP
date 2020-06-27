using ERP.Domain.Models;
using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace ERP.API.Extensions.Swagger.SwaggerExamples
{
    /// <summary>
    /// AddCompanyRequestExample
    /// </summary>
    public class AddCompanyTypeRequestExample : IExamplesProvider<AddCompanyTypeRequest>
    {
        /// <summary>
        /// AddArtistRequest
        /// </summary>
        /// <returns></returns>
        public AddCompanyTypeRequest GetExamples()
        {
            return new AddCompanyTypeRequest
            {
                Name = "Lieferant",
                Type = 1,
            };
        }
    }
}


