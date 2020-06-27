using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class ArticlePlaceMapper : IArticlePlaceMapper
    {
        private readonly ICompanyMapper _addressMapper;

        public ArticlePlaceMapper(ICompanyMapper addressMapper)
        {
            _addressMapper = addressMapper;
        }

        public ArticlePlace Map(AddArticlePlaceRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticlePlace articlePlace = new ArticlePlace
            {
                ReservedQty = request.ReservedQty,
                MinimumQty = request.MinimumQty,
                OpoQty = request.OpoQty,
                CompanyId = request.CompanyId,
            };

            return articlePlace;
        }

        public ArticlePlace Map(EditArticlePlaceRequest request)
        {
            if (request == null)
            {
                return null;
            }

            ArticlePlace articlePlace = new ArticlePlace
            {
                Id = request.Id,
                ReservedQty = request.ReservedQty,
                MinimumQty = request.MinimumQty,
                OpoQty = request.OpoQty,
                CompanyId = request.CompanyId,
            };

            return articlePlace;
        }

        public ArticlePlaceResponse Map(ArticlePlace articlePlace)
        {
            if (articlePlace == null)
            {
                return null;
            };

            ArticlePlaceResponse response = new ArticlePlaceResponse
            {
                Id = articlePlace.Id,
                ReservedQty = articlePlace.ReservedQty,
                MinimumQty = articlePlace.MinimumQty,
                OpoQty = articlePlace.OpoQty,
                CompanyId = articlePlace.CompanyId,
                Company = _addressMapper.Map(articlePlace.Company)
            };

            return response;
        }

        public IQueryable<ArticlePlaceResponse> Map(IQueryable<ArticlePlace> articlePlace)
        {

            if (articlePlace == null)
            {
                return null;
            };

            IQueryable<ArticlePlaceResponse> response = articlePlace.Select(x => new ArticlePlaceResponse()
            {
                Id = x.Id,
                ReservedQty = x.ReservedQty,
                MinimumQty = x.MinimumQty,
                OpoQty = x.OpoQty,
                CompanyId = x.CompanyId,
                Company = _addressMapper.Map(x.Company)
            });

            return response;
        }
    }
}
