using ERP.Domain.Models;
using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace ERP.API.Extensions.Swagger.SwaggerExamples
{
    /// <summary>
    /// AddCompanyRequestExample
    /// </summary>
    public class AddCountryRequestExample : IExamplesProvider<AddCountryRequest>
    {
        /// <summary>
        /// AddArtistRequest
        /// </summary>
        /// <returns></returns>
        public AddCountryRequest GetExamples()
        {
            return new AddCountryRequest
            {
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


