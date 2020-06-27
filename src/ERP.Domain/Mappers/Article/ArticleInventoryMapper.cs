using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class ArticleInventoryMapper : IArticleInventoryMapper
    {
        private readonly IArticleMapper _articleMapper;
        private readonly IArticlePlaceMapper _articlePlaceMapper;

        public ArticleInventoryMapper(IArticleMapper articleMapper, IArticlePlaceMapper articlePlaceMapper)
        {
            _articleMapper = articleMapper;
            _articlePlaceMapper = articlePlaceMapper;
        }

        public ArticleInventory Map(AddArticleInventoryRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticleInventory articleInventory = new ArticleInventory
            {
                ArticleId = request.ArticleId,
                ArticlePlaceId = request.ArticlePlaceId,
            };

            return articleInventory;
        }

        public ArticleInventory Map(EditArticleInventoryRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticleInventory articleInventory = new ArticleInventory
            {
                Id = request.Id,
                ArticleId = request.ArticleId,
                ArticlePlaceId = request.ArticlePlaceId,
            };

            return articleInventory;
        }

        public ArticleInventoryResponse Map(ArticleInventory articleInventory)
        {
            if (articleInventory == null)
            {
                return null;
            };

            ArticleInventoryResponse response = new ArticleInventoryResponse
            {
                Id = articleInventory.Id,
                ArticleId = articleInventory.ArticleId,
                Article = _articleMapper.Map(articleInventory.Article),
                ArticlePlaceId = articleInventory.ArticlePlaceId,
                ArticlePlace = _articlePlaceMapper.Map(articleInventory.ArticlePlace)
            };

            return response;
        }

        public IQueryable<ArticleInventoryResponse> Map(IQueryable<ArticleInventory> articleInventory)
        {

            if (articleInventory == null)
            {
                return null;
            };

            IQueryable<ArticleInventoryResponse> response = articleInventory.Select(x => new ArticleInventoryResponse()
            {
                Id = x.Id,
                ArticleId = x.ArticleId,
                Article = _articleMapper.Map(x.Article),
                ArticlePlaceId = x.ArticlePlaceId,
                ArticlePlace = _articlePlaceMapper.Map(x.ArticlePlace)
            });

            return response;
        }
    }
}
