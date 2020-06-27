using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.API.Extensions.Swagger.SwaggerExamples.Requests.Company
{
    /// <summary>
    /// EditCompanyRequestExample
    /// </summary>
    public class EditCompanyTypeRequestExample : IExamplesProvider<EditCompanyTypeRequest>
    {
        /// <summary>
        /// GetExamples
        /// </summary>
        /// <returns>EditCompanyRequest</returns>
        public EditCompanyTypeRequest GetExamples()
        {
            return new EditCompanyTypeRequest
            {
                Id = Guid.Parse("c415b2e6-b129-42ac-8031-71be37137e83"),
                Name = "Lieferant",
                Type = 1
            };
        }
    }
}
