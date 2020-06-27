using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.API.Extensions.Swagger.SwaggerExamples.Requests.Country
{
    /// <summary>
    /// EditCountryRequestExample
    /// </summary>
    public class EditCountryRequestExample : IExamplesProvider<EditCountryRequest>
    {
        /// <summary>
        /// GetExamples
        /// </summary>
        /// <returns>EditCountryRequest</returns>
        public EditCountryRequest GetExamples()
        {
            return new EditCountryRequest
            {
                Id = Guid.Parse("95f6fe8b-13fe-4385-b31a-dbc47a44bbe0"),
                Name = "Deutschland",
                Type = 049,
                EconomicArea = 1,
                IsoNumerical = 276,
                Iso2cc = "de",
                Iso3cc = "deu"
            };
        }
    }
}
