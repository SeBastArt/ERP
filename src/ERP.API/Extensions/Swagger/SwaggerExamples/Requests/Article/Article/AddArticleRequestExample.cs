using ERP.Domain.Models;
using ERP.Domain.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace ERP.API.Extensions.Swagger.SwaggerExamples
{
    /// <summary>
    /// AddArticleRequestExample
    /// </summary>
    public class AddArticleRequestExample : IExamplesProvider<AddArticleRequest>
    {
        /// <summary>
        /// AddArtistRequest
        /// </summary>
        /// <returns></returns>
        public AddArticleRequest GetExamples()
        {
            return new AddArticleRequest
            {
                Name = "Spiralbohrer mit Morsekegelschaft",
                MaterialType = 2,
                IsArchived = true,
                IsDiscontinued = false,
                IsBatch = true,
                IsMultistock = false,
                IsProvisionEnabled = true,
                IsDiscountEnabled = false,
                IsDisposition = true,
                IsCasting = false,
                ScaleUnitQty = 23,
                ScaleUnitType = 2,
                UnitStock = 1,
                UnitStockIn = 1,
                UnitStockOut = 1,
                DimArea = 144.0M,
                DimLength = 34.5M,
                Dim2 = 12.0M,
                Dim3 = 12.0M,
                Dim4 = 0.0M,
                SpecificWeight = 300.0M,
                ItemNumber = "3456-gfd56-23",
                DrawingNumber = "3456-gfd56-23",
                DinNorm1 = "DIN 345:2006-11",
                DinNorm2 = "",
                ArticleGroupId = Guid.Parse("7ea29fa3-e4cf-4764-938f-a0707efcde04"),
                ArticleTypeId = Guid.Parse("e6c8563d-c550-432b-bd75-2023ff28132e"),
            };
        }
    }
}


