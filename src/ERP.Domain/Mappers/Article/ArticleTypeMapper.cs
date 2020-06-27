using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class ArticleTypeMapper : IArticleTypeMapper
    {
        public ArticleType Map(AddArticleTypeRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticleType articleType = new ArticleType
            {
                Name = request.Name,
                NatureType = request.NatureType,
            };

            return articleType;
        }

        public ArticleType Map(EditArticleTypeRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticleType articleType = new ArticleType
            {
                Id = request.Id,
                Name = request.Name,
                NatureType = request.NatureType,
            };

            return articleType;
        }

        public ArticleTypeResponse Map(ArticleType articleType)
        {
            if (articleType == null)
            {
                return null;
            };

            ArticleTypeResponse response = new ArticleTypeResponse
            {
                Id = articleType.Id,
                Name = articleType.Name,
                NatureType = articleType.NatureType
            };

            return response;
        }

        public IQueryable<ArticleTypeResponse> Map(IQueryable<ArticleType> articleType)
        {

            if (articleType == null)
            {
                return null;
            };

            IQueryable<ArticleTypeResponse> response = articleType.Select(x => new ArticleTypeResponse()
            {
                Id = x.Id,
                Name = x.Name,
                NatureType = x.NatureType
            });

            return response;
        }
    }
}
