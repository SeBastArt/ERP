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
    public class ArticlePriceListInService : IArticlePriceListInService
    {
        private readonly IArticlePriceListInRespository _articlePriceListInRespository;
        private readonly IArticleRespository _articleRespository;
        private readonly ILogger<IArticlePriceListInService> _logger;
        private readonly IArticlePriceListInMapper _articlePriceListInMapper;

        public ArticlePriceListInService(
            IArticlePriceListInRespository articlePriceListInRespository, 
            IArticleRespository articleRespository, 
            ILogger<IArticlePriceListInService> logger, 
            IArticlePriceListInMapper articlePriceListInMapper)
        {
            _articlePriceListInRespository = articlePriceListInRespository;
            _articleRespository = articleRespository;
            _logger = logger;
            _articlePriceListInMapper = articlePriceListInMapper;
        }

        public async Task<ArticlePriceListInResponse> AddArticlePriceListInAsync(AddArticlePriceListInRequest request)
        {
            ArticlePriceListIn articlePriceListIn = _articlePriceListInMapper.Map(request);
            ArticlePriceListIn result = _articlePriceListInRespository.Add(articlePriceListIn);

            int modifiedRecords = await _articlePriceListInRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _articlePriceListInMapper.Map(result);
        }

        public async Task<ArticlePriceListInResponse> DeleteArticlePriceListInAsync(DeleteArticlePriceListInRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            ArticlePriceListIn result = await _articlePriceListInRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _articlePriceListInRespository.Update(result);
            int modifiedRecords = await _articlePriceListInRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _articlePriceListInMapper.Map(result);
        }

        public async Task<ArticlePriceListInResponse> EditArticlePriceListInAsync(EditArticlePriceListInRequest request)
        {
            ArticlePriceListIn existingRecord = await _articlePriceListInRespository.GetAsync(request.Id);

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

            ArticlePriceListIn entity = _articlePriceListInMapper.Map(request);
            ArticlePriceListIn result = _articlePriceListInRespository.Update(entity);

            int modifiedRecords = await _articlePriceListInRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _articlePriceListInMapper.Map(result);
        }

        public async Task<ArticlePriceListInResponse> GetArticlePriceListInAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            ArticlePriceListIn entity = await _articlePriceListInRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _articlePriceListInMapper.Map(entity);
        }

        public async Task<IEnumerable<ArticlePriceListInResponse>> GetArticlePriceListsInAsync()
        {
            IEnumerable<ArticlePriceListIn> result = await _articlePriceListInRespository.GetAsync();

            return result.Select(x => _articlePriceListInMapper.Map(x));
        }

        public IQueryable<ArticlePriceListInResponse> GetArticlePriceListsInQuery()
        {
            IQueryable<ArticlePriceListIn> result = _articlePriceListInRespository.GetQuery();
            return result.Select(x => _articlePriceListInMapper.Map(x));
        }
    }
}
