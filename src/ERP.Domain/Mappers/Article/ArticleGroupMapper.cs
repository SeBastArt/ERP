using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class ArticleGroupMapper : IArticleGroupMapper
    {
        public ArticleGroup Map(AddArticleGroupRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticleGroup articleGroup = new ArticleGroup
            {
                Name = request.Name,
            };

            return articleGroup;
        }

        public ArticleGroup Map(EditArticleGroupRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticleGroup articleGroup = new ArticleGroup
            {
                Id = request.Id,
                Name = request.Name, 
            };

            return articleGroup;
        }

        public ArticleGroupResponse Map(ArticleGroup articleGroup)
        {
            if (articleGroup == null)
            {
                return null;
            };

            ArticleGroupResponse response = new ArticleGroupResponse
            {
                Id = articleGroup.Id,
                Name = articleGroup.Name
            };

            return response;
        }

        public IQueryable<ArticleGroupResponse> Map(IQueryable<ArticleGroup> articleGroup)
        {

            if (articleGroup == null)
            {
                return null;
            };

            IQueryable<ArticleGroupResponse> response = articleGroup.Select(x => new ArticleGroupResponse()
            {
                Id = x.Id,
                Name = x.Name,
            });

            return response;
        }
    }
}
