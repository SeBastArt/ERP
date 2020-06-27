using ERP.Domain.Models;
using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace ERP.API.Extensions.Swagger.SwaggerExamples
{
    /// <summary>
    /// AddCompanyRequestExample
    /// </summary>
    public class AddCompanyRequestExample : IExamplesProvider<AddCompanyRequest>
    {
        /// <summary>
        /// AddArtistRequest
        /// </summary>
        /// <returns></returns>
        public AddCompanyRequest GetExamples()
        {
            return new AddCompanyRequest
            {
                Name = "MAPAL",
                Addition = "Tiefe Bohrungen ohne Schwingungen",
                Addition2 = "Wendeschneidplatten bearbeiten",
                Street = "12 rue Marius Tercé Parc d’activités St Martin du Touch",
                PostCode = "31300",
                City = "TOULOUSE",
                Email = "info@mapal.com",
                Phone = "+33 (0) 562 475555",
                Fax = "+33 (0) 562 475556",
                VatId = "FR29377504832",
                TimeZone = "Paris",
                LogoId = Guid.Parse("95982efe-e0ff-4560-fc53-08d806d6ac61"),
                ParentId = Guid.Parse("a603639f-feba-4ba2-a94a-1283e0837df4"),
                CountryId = Guid.Parse("68ff1922-83df-41cb-8ba9-eb6364f0b08c"),
                CompanyTypeId = Guid.Parse("9bd620cb-827a-4517-8e94-258f85da8fd7"),
            };
        }
    }
}


