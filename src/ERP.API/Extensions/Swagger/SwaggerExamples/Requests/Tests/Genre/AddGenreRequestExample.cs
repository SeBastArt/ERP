
using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace ERP.API.Extensions.Swagger.SwaggerExamples
{
    /// <summary>
    /// AddGenreRequestExample
    /// </summary>
    public class AddGenreRequestExample : IExamplesProvider<AddGenreRequest>
    {
        /// <summary>
        /// AddArtistRequest
        /// </summary>
        /// <returns></returns>
        public AddGenreRequest GetExamples()
        {
            return new AddGenreRequest
            {
                GenreDescription = "Anderson Paak."
            };
        }
    }
}
