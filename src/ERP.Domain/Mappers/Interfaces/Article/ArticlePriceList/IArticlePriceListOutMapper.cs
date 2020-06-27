using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Domain.Mappers
{
    public interface IArticlePriceListOutMapper
    {
        ArticlePriceListOut Map(AddArticlePriceListOutRequest request);
        ArticlePriceListOut Map(EditArticlePriceListOutRequest request);
        ArticlePriceListOutResponse Map(ArticlePriceListOut item);
    }
}
