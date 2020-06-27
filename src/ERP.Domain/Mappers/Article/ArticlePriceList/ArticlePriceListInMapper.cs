using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class ArticlePriceListInMapper : IArticlePriceListInMapper
    {
        private readonly IArticleMapper _articleMapper;
        private readonly IArticleRangeMapper _articleRangeMapper;

        public ArticlePriceListInMapper(IArticleMapper articleMapper, IArticleRangeMapper articleRangeMapper)
        {
            _articleMapper = articleMapper;
            _articleRangeMapper = articleRangeMapper;
        }

        public ArticlePriceListIn Map(AddArticlePriceListInRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticlePriceListIn articlePriceListIn = new ArticlePriceListIn
            {
                ValidFrom = request.ValidFrom,
                Validto = request.Validto,
                ScaleUnitQty = request.ScaleUnitQty,
                ScaleUnitType = request.ScaleUnitType,
                UnitOrder = request.UnitOrder,
                MinOrderQty = request.MinOrderQty,
                IsMultipleOrderQty = request.IsMultipleOrderQty,
                ArticleId = request.ArticleId,
            };

            return articlePriceListIn;
        }

        public ArticlePriceListIn Map(EditArticlePriceListInRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticlePriceListIn articlePriceListIn = new ArticlePriceListIn
            {
                Id = request.Id,
                ValidFrom = request.ValidFrom,
                Validto = request.Validto,
                ScaleUnitQty = request.ScaleUnitQty,
                ScaleUnitType = request.ScaleUnitType,
                UnitOrder = request.UnitOrder,
                MinOrderQty = request.MinOrderQty,
                IsMultipleOrderQty = request.IsMultipleOrderQty,
                ArticleId = request.ArticleId,
            };

            return articlePriceListIn;
        }

        public ArticlePriceListInResponse Map(ArticlePriceListIn articlePriceListIn)
        {
            if (articlePriceListIn == null)
            {
                return null;
            };

            ArticlePriceListInResponse response = new ArticlePriceListInResponse
            {
                Id = articlePriceListIn.Id,
                ValidFrom = articlePriceListIn.ValidFrom,
                Validto = articlePriceListIn.Validto,
                ScaleUnitQty = articlePriceListIn.ScaleUnitQty,
                ScaleUnitType = articlePriceListIn.ScaleUnitType,
                UnitOrder = articlePriceListIn.UnitOrder,
                MinOrderQty = articlePriceListIn.MinOrderQty,
                IsMultipleOrderQty = articlePriceListIn.IsMultipleOrderQty,
                ArticleId = articlePriceListIn.ArticleId,
                Article = _articleMapper.Map(articlePriceListIn.Article),
                ArticleRanges = articlePriceListIn.ArticleRanges.Select(x => _articleRangeMapper.Map(x)).ToList()
            };

            return response;
        }

        public IQueryable<ArticlePriceListInResponse> Map(IQueryable<ArticlePriceListIn> articlePriceListIn)
        {

            if (articlePriceListIn == null)
            {
                return null;
            };

            IQueryable<ArticlePriceListInResponse> response = articlePriceListIn.Select(x => new ArticlePriceListInResponse()
            {
                Id = x.Id,
                ValidFrom = x.ValidFrom,
                Validto = x.Validto,
                ScaleUnitQty = x.ScaleUnitQty,
                ScaleUnitType = x.ScaleUnitType,
                UnitOrder = x.UnitOrder,
                MinOrderQty = x.MinOrderQty,
                IsMultipleOrderQty = x.IsMultipleOrderQty,
                ArticleId = x.ArticleId,
                Article = _articleMapper.Map(x.Article),
                ArticleRanges = x.ArticleRanges.Select(x => _articleRangeMapper.Map(x)).ToList()
            });

            return response;
        }
    }
}
