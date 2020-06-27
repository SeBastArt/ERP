using ERP.Domain.Models;
using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace ERP.API.Extensions.Swagger.SwaggerExamples
{
    /// <summary>
    /// AddPersonRequestExample
    /// </summary>
    public class AddPersonRequestExample : IExamplesProvider<AddPersonRequest>
    {
        /// <summary>
        /// AddArtistRequest
        /// </summary>
        /// <returns></returns>
        public AddPersonRequest GetExamples()
        {
            return new AddPersonRequest
            {
                FirstName = "Wendeschneidplatten bearbeiten",
                LastName = "Tiefe Bohrungen ohne Schwingungen",
                Department = "12 rue Marius Tercé Parc d’activités St Martin du Touch",
                Sex = "Male",
                Email = "info@mapal.com",
                PhonePrivate = "+33 (0) 562 475555",
                PhoneOffice = "+33 (0) 562 475556",
                PictureId = Guid.Parse("ec3a1f95-e99e-4eba-b406-87ad89ac6531"),
            };
        }
    }
}


