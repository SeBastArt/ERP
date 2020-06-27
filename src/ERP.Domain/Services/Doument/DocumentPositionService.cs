using ERP.Domain.Extensions;
using ERP.Domain.Logging;
using ERP.Domain.Mappers;
using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Respositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public class DocumentPositionService : IDocumentPositionService
    {
        private readonly IDocumentPositionRespository _documentPositionRespository;
        private readonly IDocumentRespository _documentRespository;
        private readonly IArticleRespository _articleRespository;
        private readonly ILogger<IDocumentPositionService> _logger;
        private readonly IDocumentPositionMapper _documentPositionMapper;

        public DocumentPositionService(
            IDocumentPositionRespository documentPositionRespository, 
            IDocumentRespository documentRespository, 
            IArticleRespository articleRespository, 
            ILogger<IDocumentPositionService> logger, 
            IDocumentPositionMapper documentPositionMapper)
        {
            _documentPositionRespository = documentPositionRespository;
            _documentRespository = documentRespository;
            _articleRespository = articleRespository;
            _logger = logger;
            _documentPositionMapper = documentPositionMapper;
        }

        public async Task<DocumentPositionResponse> AddDocumentPositionAsync(AddDocumentPositionRequest request)
        {
            DocumentPosition documentPosition = _documentPositionMapper.Map(request);
            DocumentPosition result = _documentPositionRespository.Add(documentPosition);

            int modifiedRecords = await _documentPositionRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _documentPositionMapper.Map(result);
        }

        public async Task<DocumentPositionResponse> DeleteDocumentPositionAsync(DeleteDocumentPositionRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            DocumentPosition result = await _documentPositionRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _documentPositionRespository.Update(result);
            int modifiedRecords = await _documentPositionRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _documentPositionMapper.Map(result);
        }

        public async Task<DocumentPositionResponse> EditDocumentPositionAsync(EditDocumentPositionRequest request)
        {
            DocumentPosition existingRecord = await _documentPositionRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            if (request.ArticleId != null)
            {
                Article existingArticle = await _articleRespository.GetAsync(request.ArticleId);
                if (existingArticle == null)
                {
                    throw new NotFoundException($"Article with {request.ArticleId} is not present");
                }
            }

            if (request.ParentId != null)
            {
                DocumentPosition existingDocumentPosition = await _documentPositionRespository.GetAsync(request.ParentId);
                if (existingDocumentPosition == null)
                {
                    throw new NotFoundException($"Parent DocumentPosition with {request.ParentId} is not present");
                }
            }

            if (request.DocumentId != null)
            {
                Document existingDocument = await _documentRespository.GetAsync(request.DocumentId);
                if (existingDocument == null)
                {
                    throw new NotFoundException($"Document with {request.DocumentId} is not present");
                }
            }

            DocumentPosition entity = _documentPositionMapper.Map(request);
            DocumentPosition result = _documentPositionRespository.Update(entity);

            int modifiedRecords = await _documentPositionRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _documentPositionMapper.Map(result);
        }

        public async Task<DocumentPositionResponse> GetDocumentPositionAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            DocumentPosition entity = await _documentPositionRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _documentPositionMapper.Map(entity);
        }

        public async Task<IEnumerable<DocumentPositionResponse>> GetDocumentPositionsAsync()
        {
            IEnumerable<DocumentPosition> result = await _documentPositionRespository.GetAsync();

            return result.Select(x => _documentPositionMapper.Map(x));
        }

        public IQueryable<DocumentPositionResponse> GetDocumentPositionsQuery()
        {
            IQueryable<DocumentPosition> result = _documentPositionRespository.GetQuery();
            return result.Select(x => _documentPositionMapper.Map(x));
        }
    }
}
