using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class ArticleMapper : IArticleMapper
    {
        private readonly IArticleGroupMapper _articleGroupMapper;
        private readonly IArticleInventoryMapper _articleInventoryMapper;
        private readonly IArticleRangeMapper _articleRangeMapper;
        private readonly IArticleTypeMapper _articleTypeMapper;
        private readonly IFAGBinaryMapper _fagBinaryMapper;

        public ArticleMapper(IArticleGroupMapper articleGroupMapper, IArticleInventoryMapper articleInventoryMapper, IArticleRangeMapper articleRangeMapper, IArticleTypeMapper articleTypeMapper, IFAGBinaryMapper fagBinaryMapper)
        {
            _articleGroupMapper = articleGroupMapper;
            _articleInventoryMapper = articleInventoryMapper;
            _articleRangeMapper = articleRangeMapper;
            _articleTypeMapper = articleTypeMapper;
            _fagBinaryMapper = fagBinaryMapper;
        }

        public Article Map(AddArticleRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Article article = new Article
            {
                Name = request.Name,
                MaterialType = request.MaterialType,
                IsArchived = request.IsArchived,
                IsDiscontinued = request.IsDiscontinued,
                IsBatch = request.IsBatch,
                IsMultistock = request.IsMultistock,
                IsProvisionEnabled = request.IsProvisionEnabled,
                IsDiscountEnabled = request.IsDiscountEnabled,
                IsDisposition = request.IsDisposition,
                IsCasting = request.IsCasting,
                ScaleUnitQty = request.ScaleUnitQty,
                ScaleUnitType = request.ScaleUnitType,
                UnitStock = request.UnitStock,
                UnitStockIn = request.UnitStockIn,
                UnitStockOut = request.UnitStockOut,
                DimArea = request.DimArea,
                DimLength = request.DimLength,
                Dim2 = request.Dim2,
                Dim3 = request.Dim3,
                Dim4 = request.Dim4,
                SpecificWeight = request.SpecificWeight,
                ItemNumber = request.ItemNumber,
                DrawingNumber = request.DrawingNumber,
                DinNorm1 = request.DinNorm1,
                DinNorm2 = request.DinNorm2,
                ArticleGroupId = request.ArticleGroupId,
                ArticleTypeId = request.ArticleTypeId,
            };

            return article;
        }

        public Article Map(EditArticleRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Article article = new Article
            {
                Id = request.Id,
                Name = request.Name,
                MaterialType = request.MaterialType,
                IsArchived = request.IsArchived,
                IsDiscontinued = request.IsDiscontinued,
                IsBatch = request.IsBatch,
                IsMultistock = request.IsMultistock,
                IsProvisionEnabled = request.IsProvisionEnabled,
                IsDiscountEnabled = request.IsDiscountEnabled,
                IsDisposition = request.IsDisposition,
                IsCasting = request.IsCasting,
                ScaleUnitQty = request.ScaleUnitQty,
                ScaleUnitType = request.ScaleUnitType,
                UnitStock = request.UnitStock,
                UnitStockIn = request.UnitStockIn,
                UnitStockOut = request.UnitStockOut,
                DimArea = request.DimArea,
                DimLength = request.DimLength,
                Dim2 = request.Dim2,
                Dim3 = request.Dim3,
                Dim4 = request.Dim4,
                SpecificWeight = request.SpecificWeight,
                ItemNumber = request.ItemNumber,
                DrawingNumber = request.DrawingNumber,
                DinNorm1 = request.DinNorm1,
                DinNorm2 = request.DinNorm2,
                ArticleGroupId = request.ArticleGroupId,
                ArticleTypeId = request.ArticleTypeId,
            };

            return article;
        }

        public ArticleResponse Map(Article article)
        {
            if (article == null)
            {
                return null;
            };

            ArticleResponse response = new ArticleResponse
            {
                Id = article.Id,
                Name = article.Name,
                MaterialType = article.MaterialType,
                IsArchived = article.IsArchived,
                IsDiscontinued = article.IsDiscontinued,
                IsBatch = article.IsBatch,
                IsMultistock = article.IsMultistock,
                IsProvisionEnabled = article.IsProvisionEnabled,
                IsDiscountEnabled = article.IsDiscountEnabled,
                IsDisposition = article.IsDisposition,
                IsCasting = article.IsCasting,
                ScaleUnitQty = article.ScaleUnitQty,
                ScaleUnitType = article.ScaleUnitType,
                UnitStock = article.UnitStock,
                UnitStockIn = article.UnitStockIn,
                UnitStockOut = article.UnitStockOut,
                DimArea = article.DimArea,
                DimLength = article.DimLength,
                Dim2 = article.Dim2,
                Dim3 = article.Dim3,
                Dim4 = article.Dim4,
                SpecificWeight = article.SpecificWeight,
                ItemNumber = article.ItemNumber,
                DrawingNumber = article.DrawingNumber,
                DinNorm1 = article.DinNorm1,
                DinNorm2 = article.DinNorm2,
                ArticleGroupId = article.ArticleGroupId,
                ArticleGroup = _articleGroupMapper.Map(article.ArticleGroup),
                ArticleTypeId = article.ArticleTypeId,
                ArticleType = _articleTypeMapper.Map(article.ArticleType),
                ArticleInventories = article.ArticleInventories.Select(x => _articleInventoryMapper.Map(x)).ToList(),
                ArticleRanges = article.ArticleRanges.Select(x => _articleRangeMapper.Map(x)).ToList(),
                Pictures = article.Pictures.Select(x => _fagBinaryMapper.Map(x)).ToList()

            };

            return response;
        }

        public IQueryable<ArticleResponse> Map(IQueryable<Article> article)
        {

            if (article == null)
            {
                return null;
            };

            IQueryable<ArticleResponse> response = article.Select(x => new ArticleResponse()
            {
                Id = x.Id,
                Name = x.Name,
                MaterialType = x.MaterialType,
                IsArchived = x.IsArchived,
                IsDiscontinued = x.IsDiscontinued,
                IsBatch = x.IsBatch,
                IsMultistock = x.IsMultistock,
                IsProvisionEnabled = x.IsProvisionEnabled,
                IsDiscountEnabled = x.IsDiscountEnabled,
                IsDisposition = x.IsDisposition,
                IsCasting = x.IsCasting,
                ScaleUnitQty = x.ScaleUnitQty,
                ScaleUnitType = x.ScaleUnitType,
                UnitStock = x.UnitStock,
                UnitStockIn = x.UnitStockIn,
                UnitStockOut = x.UnitStockOut,
                DimArea = x.DimArea,
                DimLength = x.DimLength,
                Dim2 = x.Dim2,
                Dim3 = x.Dim3,
                Dim4 = x.Dim4,
                SpecificWeight = x.SpecificWeight,
                ItemNumber = x.ItemNumber,
                DrawingNumber = x.DrawingNumber,
                DinNorm1 = x.DinNorm1,
                DinNorm2 = x.DinNorm2,
                ArticleGroupId = x.ArticleGroupId,
                ArticleGroup = _articleGroupMapper.Map(x.ArticleGroup),
                ArticleTypeId = x.ArticleTypeId,
                ArticleType = _articleTypeMapper.Map(x.ArticleType),
                ArticleInventories = x.ArticleInventories.Select(x => _articleInventoryMapper.Map(x)).ToList(),
                ArticleRanges = x.ArticleRanges.Select(x => _articleRangeMapper.Map(x)).ToList(),
                Pictures = x.Pictures.Select(x => _fagBinaryMapper.Map(x)).ToList()
            });

            return response;
        }
    }
}
