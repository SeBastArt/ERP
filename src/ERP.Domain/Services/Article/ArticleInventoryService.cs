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
    public class ArticleInventoryService : IArticleInventoryService
    {
        private readonly IArticleInventoryRespository _articleInventoryRespository;
        private readonly ILogger<IArticleInventoryService> _logger;
        private readonly IArticleInventoryMapper _articleInventoryMapper;
        private readonly IArticlePlaceRespository _articlePlacesRespository;

        public ArticleInventoryService(IArticleInventoryRespository articleInventoryRespository, 
            ILogger<IArticleInventoryService> logger, 
            IArticleInventoryMapper articleInventoryMapper, IArticlePlaceRespository articlePlacesRespository)
        {
            _articleInventoryRespository = articleInventoryRespository;
            _logger = logger;
            _articleInventoryMapper = articleInventoryMapper;
            _articlePlacesRespository = articlePlacesRespository;
        }

        public async Task<ArticleInventoryResponse> AddArticleInventoryAsync(AddArticleInventoryRequest request)
        {
            ArticleInventory articleInventory = _articleInventoryMapper.Map(request);
            ArticleInventory result = _articleInventoryRespository.Add(articleInventory);

            int modifiedRecords = await _articleInventoryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _articleInventoryMapper.Map(result);
        }

        public async Task<ArticleInventoryResponse> DeleteArticleInventoryAsync(DeleteArticleInventoryRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            ArticleInventory result = await _articleInventoryRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _articleInventoryRespository.Update(result);
            int modifiedRecords = await _articleInventoryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _articleInventoryMapper.Map(result);
        }

        public async Task<ArticleInventoryResponse> EditArticleInventoryAsync(EditArticleInventoryRequest request)
        {
            ArticleInventory existingRecord = await _articleInventoryRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            if (request.ArticlePlaceId != null)
            {
                ArticlePlace existingArticlePlace = await _articlePlacesRespository.GetAsync(request.ArticlePlaceId);
                if (existingArticlePlace == null)
                {
                    throw new NotFoundException($"ArticlePlace with {request.ArticlePlaceId} is not present");
                }
            }

            ArticleInventory entity = _articleInventoryMapper.Map(request);
            ArticleInventory result = _articleInventoryRespository.Update(entity);

            int modifiedRecords = await _articleInventoryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _articleInventoryMapper.Map(result);
        }

        public async Task<ArticleInventoryResponse> GetArticleInventoryAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            ArticleInventory entity = await _articleInventoryRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _articleInventoryMapper.Map(entity);
        }

        public async Task<IEnumerable<ArticleInventoryResponse>> GetArticleInventoriesAsync()
        {
            IEnumerable<ArticleInventory> result = await _articleInventoryRespository.GetAsync();

            return result.Select(x => _articleInventoryMapper.Map(x));
        }

        public IQueryable<ArticleInventoryResponse> GetArticleInventoriesQuery()
        {
            IQueryable<ArticleInventory> result = _articleInventoryRespository.GetQuery();
            return result.Select(x => _articleInventoryMapper.Map(x));
        }
    }
}
