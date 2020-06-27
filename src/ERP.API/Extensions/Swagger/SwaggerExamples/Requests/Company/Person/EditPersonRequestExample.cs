using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.API.Extensions.Swagger.SwaggerExamples.Requests.Person
{
    /// <summary>
    /// EditPersonRequestExample
    /// </summary>
    public class EditPersonRequestExample : IExamplesProvider<EditPersonRequest>
    {
        /// <summary>
        /// GetExamples
        /// </summary>
        /// <returns>EditPersonRequest</returns>
        public EditPersonRequest GetExamples()
        {
            return new EditPersonRequest
            {
                Id = Guid.Parse("298a3296-8422-4969-b61f-f2ba5e344afe"),
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
