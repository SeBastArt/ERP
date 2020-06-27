using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class ArticleRangeMapper : IArticleRangeMapper
    {
        private readonly IArticleMapper _articleMapper;
        private readonly IArticlePriceListInMapper _articlepriceListInMapper;
        private readonly IArticlePriceListOutMapper _articlepriceListOutMapper;

        public ArticleRangeMapper(IArticleMapper articleMapper, IArticlePriceListInMapper articlepriceListInMapper, IArticlePriceListOutMapper articlepriceListOutMapper)
        {
            _articleMapper = articleMapper;
            _articlepriceListInMapper = articlepriceListInMapper;
            _articlepriceListOutMapper = articlepriceListOutMapper;
        }

        public ArticleRange Map(AddArticleRangeRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticleRange articleRange = new ArticleRange
            {
                Quantity = request.Quantity,
                NetPrice = request.NetPrice,
                Discount = request.Discount,
                Addition = request.Addition,
                Price = request.Price,
                ArticleId = request.ArticleId,
                ArticlePriceListInId = request.ArticlePriceListInId,
                ArticlePriceListOutId = request.ArticlePriceListOutId,
            };

            return articleRange;
        }

        public ArticleRange Map(EditArticleRangeRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticleRange articleRange = new ArticleRange
            {
                Id = request.Id,
                Quantity = request.Quantity,
                NetPrice = request.NetPrice,
                Discount = request.Discount,
                Addition = request.Addition,
                Price = request.Price,
                ArticleId = request.ArticleId,
                ArticlePriceListInId = request.ArticlePriceListInId,
                ArticlePriceListOutId = request.ArticlePriceListOutId,
            };

            return articleRange;
        }

        public ArticleRangeResponse Map(ArticleRange articleRange)
        {
            if (articleRange == null)
            {
                return null;
            };

            ArticleRangeResponse response = new ArticleRangeResponse
            {
                Id = articleRange.Id,
                Quantity = articleRange.Quantity,
                NetPrice = articleRange.NetPrice,
                Discount = articleRange.Discount,
                Addition = articleRange.Addition,
                Price = articleRange.Price,
                ArticleId = articleRange.ArticleId,
                Article = _articleMapper.Map(articleRange.Article),
                ArticlePriceListInId = articleRange.ArticlePriceListInId,
                ArticlePriceListIn = _articlepriceListInMapper.Map(articleRange.ArticlePriceListIn),
                ArticlePriceListOutId = articleRange.ArticlePriceListOutId,
                ArticlePriceListOut = _articlepriceListOutMapper.Map(articleRange.ArticlePriceListOut)
            };

            return response;
        }

        public IQueryable<ArticleRangeResponse> Map(IQueryable<ArticleRange> articleRange)
        {

            if (articleRange == null)
            {
                return null;
            };

            IQueryable<ArticleRangeResponse> response = articleRange.Select(x => new ArticleRangeResponse()
            {
                Id = x.Id,
                Quantity = x.Quantity,
                NetPrice = x.NetPrice,
                Discount = x.Discount,
                Addition = x.Addition,
                Price = x.Price,
                ArticleId = x.ArticleId,
                Article = _articleMapper.Map(x.Article),
                ArticlePriceListInId = x.ArticlePriceListInId,
                ArticlePriceListIn = _articlepriceListInMapper.Map(x.ArticlePriceListIn),
                ArticlePriceListOutId = x.ArticlePriceListOutId,
                ArticlePriceListOut = _articlepriceListOutMapper.Map(x.ArticlePriceListOut)
            });

            return response;
        }
    }
}
