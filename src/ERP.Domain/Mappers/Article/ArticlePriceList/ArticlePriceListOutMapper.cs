using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class ArticlePriceListOutMapper : IArticlePriceListOutMapper
    {
        private readonly IArticleMapper _articleMapper;
        private readonly IArticleRangeMapper _articleRangeMapper;

        public ArticlePriceListOutMapper(IArticleMapper articleMapper, IArticleRangeMapper articleRangeMapper)
        {
            _articleMapper = articleMapper;
            _articleRangeMapper = articleRangeMapper;
        }

        public ArticlePriceListOut Map(AddArticlePriceListOutRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticlePriceListOut articlePriceListOut = new ArticlePriceListOut
            {
                Priority = request.Priority,
                ReorderTime = request.ReorderTime,
                ScaleUnitQty = request.ScaleUnitQty,
                ScaleUnitType = request.ScaleUnitType,
                UnitOrder = request.UnitOrder,
                MinOrderQty = request.MinOrderQty,
                IsMultipleOrderQty = request.IsMultipleOrderQty,
                ArticleId = request.ArticleId,
            };

            return articlePriceListOut;
        }

        public ArticlePriceListOut Map(EditArticlePriceListOutRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticlePriceListOut articlePriceListOut = new ArticlePriceListOut
            {
                Id = request.Id,
                Priority = request.Priority,
                ReorderTime = request.ReorderTime,
                ScaleUnitQty = request.ScaleUnitQty,
                ScaleUnitType = request.ScaleUnitType,
                UnitOrder = request.UnitOrder,
                MinOrderQty = request.MinOrderQty,
                IsMultipleOrderQty = request.IsMultipleOrderQty,
                ArticleId = request.ArticleId,
            };

            return articlePriceListOut;
        }

        public ArticlePriceListOutResponse Map(ArticlePriceListOut articlePriceListOut)
        {
            if (articlePriceListOut == null)
            {
                return null;
            };

            ArticlePriceListOutResponse response = new ArticlePriceListOutResponse
            {
                Id = articlePriceListOut.Id,
                Priority = articlePriceListOut.Priority,
                ReorderTime = articlePriceListOut.ReorderTime,
                ScaleUnitQty = articlePriceListOut.ScaleUnitQty,
                ScaleUnitType = articlePriceListOut.ScaleUnitType,
                UnitOrder = articlePriceListOut.UnitOrder,
                MinOrderQty = articlePriceListOut.MinOrderQty,
                IsMultipleOrderQty = articlePriceListOut.IsMultipleOrderQty,
                ArticleId = articlePriceListOut.ArticleId,
                ArticleRanges = articlePriceListOut.ArticleRanges.Select(x => _articleRangeMapper.Map(x)).ToList()
            };

            return response;
        }

        public IQueryable<ArticlePriceListOutResponse> Map(IQueryable<ArticlePriceListOut> articlePriceListOut)
        {

            if (articlePriceListOut == null)
            {
                return null;
            };

            IQueryable<ArticlePriceListOutResponse> response = articlePriceListOut.Select(x => new ArticlePriceListOutResponse()
            {
                Id = x.Id,
                Priority = x.Priority,
                ReorderTime = x.ReorderTime,
                ScaleUnitQty = x.ScaleUnitQty,
                ScaleUnitType = x.ScaleUnitType,
                UnitOrder = x.UnitOrder,
                MinOrderQty = x.MinOrderQty,
                IsMultipleOrderQty = x.IsMultipleOrderQty,
                ArticleId = x.ArticleId,
                ArticleRanges = x.ArticleRanges.Select(x => _articleRangeMapper.Map(x)).ToList()
            });

            return response;
        }
    }
}
