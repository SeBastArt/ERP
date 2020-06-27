using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class DocumentPositionMapper : IDocumentPositionMapper
    {
        private readonly IDocumentPositionMapper _documentPositionMapper;
        private readonly IDocumentMapper _documentMapper;
        private readonly IArticleMapper _articleMapper;

        public DocumentPositionMapper(IDocumentPositionMapper documentPositionMapper, IDocumentMapper documentMapper, IArticleMapper articleMapper)
        {
            _documentPositionMapper = documentPositionMapper;
            _documentMapper = documentMapper;
            _articleMapper = articleMapper;
        }

        public DocumentPosition Map(AddDocumentPositionRequest request)
        {
            if (request == null)
            {
                return null;
            }

            DocumentPosition documentPosition = new DocumentPosition
            {
                PositionNumberText = request.PositionNumberText,
                ArticleNameExtern = request.ArticleNameExtern,
                Quantity = request.Quantity,
                ScaleUnitQty = request.ScaleUnitQty,
                ScaleUnitType = request.ScaleUnitType,
                ScaleUnit = request.ScaleUnit,
                DeliveryQty = request.DeliveryQty,
                IsPartialDelivered = request.IsPartialDelivered,
                PriceBase = request.PriceBase,
                PricePerUnit = request.PricePerUnit,
                PriceTotal = request.PricePerUnit,
                SalesTaxPercent = request.SalesTaxPercent,
                ParentId = request.ParentId,
                DocumentId = request.DocumentId,
                ArticleId = request.ArticleId,
            };
 
            return documentPosition;
        }

        public DocumentPosition Map(EditDocumentPositionRequest request)
        {
            if (request == null)
            {
                return null;
            }

            DocumentPosition documentPosition = new DocumentPosition
            {
                Id = request.Id,
                PositionNumberText = request.PositionNumberText,
                ArticleNameExtern = request.ArticleNameExtern,
                Quantity = request.Quantity,
                ScaleUnitQty = request.ScaleUnitQty,
                ScaleUnitType = request.ScaleUnitType,
                ScaleUnit = request.ScaleUnit,
                DeliveryQty = request.DeliveryQty,
                IsPartialDelivered = request.IsPartialDelivered,
                PriceBase = request.PriceBase,
                PricePerUnit = request.PricePerUnit,
                PriceTotal = request.PricePerUnit,
                SalesTaxPercent = request.SalesTaxPercent,
                ParentId = request.ParentId,
                DocumentId = request.DocumentId,
                ArticleId = request.ArticleId,
            };

            return documentPosition;
        }

        public DocumentPositionResponse Map(DocumentPosition documentPosition)
        {
            if (documentPosition == null)
            {
                return null;
            };

            DocumentPositionResponse response = new DocumentPositionResponse
            {
                Id = documentPosition.Id,
                PositionNumberText = documentPosition.PositionNumberText,
                ArticleNameExtern = documentPosition.ArticleNameExtern,
                Quantity = documentPosition.Quantity,
                ScaleUnitQty = documentPosition.ScaleUnitQty,
                ScaleUnitType = documentPosition.ScaleUnitType,
                ScaleUnit = documentPosition.ScaleUnit,
                DeliveryQty = documentPosition.DeliveryQty,
                IsPartialDelivered = documentPosition.IsPartialDelivered,
                PriceBase = documentPosition.PriceBase,
                PricePerUnit = documentPosition.PricePerUnit,
                PriceTotal = documentPosition.PricePerUnit,
                SalesTaxPercent = documentPosition.SalesTaxPercent,

                ParentId = (Guid)documentPosition.ParentId,
                Parent = _documentPositionMapper.Map(documentPosition.Parent),
                DocumentId = documentPosition.DocumentId,
                Document = _documentMapper.Map(documentPosition.Document),
                ArticleId = documentPosition.ArticleId,
                Article = _articleMapper.Map(documentPosition.Article),
            };

            return response;
        }

        public IQueryable<DocumentPositionResponse> Map(IQueryable<DocumentPosition> documentPosition)
        {

            if (documentPosition == null)
            {
                return null;
            };

            IQueryable<DocumentPositionResponse> response = documentPosition.Select(x => new DocumentPositionResponse()
            {
                Id = x.Id,
                PositionNumberText = x.PositionNumberText,
                ArticleNameExtern = x.ArticleNameExtern,
                Quantity = x.Quantity,
                ScaleUnitQty = x.ScaleUnitQty,
                ScaleUnitType = x.ScaleUnitType,
                ScaleUnit = x.ScaleUnit,
                DeliveryQty = x.DeliveryQty,
                IsPartialDelivered = x.IsPartialDelivered,
                PriceBase = x.PriceBase,
                PricePerUnit = x.PricePerUnit,
                PriceTotal = x.PricePerUnit,
                SalesTaxPercent = x.SalesTaxPercent,

                ParentId = (Guid)x.ParentId,
                Parent = _documentPositionMapper.Map(x.Parent),
                DocumentId = x.DocumentId,
                Document = _documentMapper.Map(x.Document),
                ArticleId = x.ArticleId,
                Article = _articleMapper.Map(x.Article),
            });

            return response;
        }
    }
}
