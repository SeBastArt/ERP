using ERP.Domain.Responses;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.API.Extensions.Swagger.SwaggerExamples.Responses
{
    /// <summary>
    /// PagedItemResponseExample
    /// </summary>
    public class PagedItemResponseExample : IExamplesProvider<RespContainer<ApiResult<ItemResponse>>>
    {
        /// <summary>
        /// AddArtistRequest
        /// </summary>
        /// <returns></returns>
        public RespContainer<ApiResult<ItemResponse>> GetExamples()
        {

            List<ItemResponse> itemList = new List<ItemResponse>
            {
                new ItemResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "DAMN.",
                    Description = "DAMN. by Kendrick Lamar",
                    LabelName = "TDE, Top Dawg Entertainment",
                    Price = new PriceResponse
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
                }
            };
            Task<ApiResult<ItemResponse>> pagedItemsTask = Task.Run(() => ApiResult<ItemResponse>.CreateAsync(itemList.AsQueryable(), 20, 10, "Name", "ASC"));
            return RespContainer.Ok(pagedItemsTask.Result, string.Format(@"{0} Items found", itemList.Count()));
        }
    }
}
