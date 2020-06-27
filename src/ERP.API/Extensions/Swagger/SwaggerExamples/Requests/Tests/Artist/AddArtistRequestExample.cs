using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace ERP.API.Extensions.Swagger.SwaggerExamples
{
    /// <summary>
    /// AddArtistRequestExample
    /// </summary>
    public class AddArtistRequestExample : IExamplesProvider<AddArtistRequest>
    {
        /// <summary>
        /// AddArtistRequest
        /// </summary>
        /// <returns></returns>
        public AddArtistRequest GetExamples()
        {
            return new AddArtistRequest
            {
                ArtistName = "Anderson Paak.",
            };
        }
    }
}
