using ERP.Domain.Models;
using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace ERP.API.Extensions.Swagger.SwaggerExamples
{
    /// <summary>
    /// AddItemRequestExample
    /// </summary>
    public class AddItemRequestExample : IExamplesProvider<AddItemRequest>
    {
        /// <summary>
        /// AddArtistRequest
        /// </summary>
        /// <returns></returns>
        public AddItemRequest GetExamples()
        {
            return new AddItemRequest
            {
                Name = "DAMN.",
                Description = "DAMN. by Kendrick Lamar",
                LabelName = "TDE, Top Dawg Entertainment",
                Price = new Price
                {
                    Amount = Convert.ToDecimal(34.5),
                    Currency = "EUR"
                },
                PictureUri = "https://mycdn.com/pictures/45345345",
                ReleaseDate = DateTime.Parse("2016-01-01T00:00:00+00:00"),
                Format = "Vinyl 33g",
                AvailableStock = 5,
                GenreId = Guid.Parse("673cc719-6443-4d06-f21e-08d806d69e5d"),
                ArtistId = Guid.Parse("95982efe-e0ff-4560-fc53-08d806d6ac61"),
            };
        }
    }
}
