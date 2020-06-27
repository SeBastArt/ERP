using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Domain.Mappers
{
    public interface IArticlePriceListInMapper
    {
        ArticlePriceListIn Map(AddArticlePriceListInRequest request);
        ArticlePriceListIn Map(EditArticlePriceListInRequest request);
        ArticlePriceListInResponse Map(ArticlePriceListIn item);
    }
}
