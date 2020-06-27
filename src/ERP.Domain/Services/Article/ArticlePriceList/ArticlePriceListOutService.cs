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
    public class ArticlePriceListOutService : IArticlePriceListOutService
    {
        private readonly IArticlePriceListOutRespository _articlePriceListOutRespository;
        private readonly IArticleRespository _articleRespository;
        private readonly ILogger<IArticlePriceListOutService> _logger;
        private readonly IArticlePriceListOutMapper _articlePriceListOutMapper;

        public ArticlePriceListOutService(
            IArticlePriceListOutRespository articlePriceListOutRespository,
            IArticleRespository articleRespository,
            ILogger<IArticlePriceListOutService> logger,
            IArticlePriceListOutMapper articlePriceListOutMapper)
        {
            _articlePriceListOutRespository = articlePriceListOutRespository;
            _articleRespository = articleRespository;
            _logger = logger;
            _articlePriceListOutMapper = articlePriceListOutMapper;
        }

        public async Task<ArticlePriceListOutResponse> AddArticlePriceListOutAsync(AddArticlePriceListOutRequest request)
        {
            ArticlePriceListOut articlePriceListOut = _articlePriceListOutMapper.Map(request);
            ArticlePriceListOut result = _articlePriceListOutRespository.Add(articlePriceListOut);

            int modifiedRecords = await _articlePriceListOutRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _articlePriceListOutMapper.Map(result);
        }

        public async Task<ArticlePriceListOutResponse> DeleteArticlePriceListOutAsync(DeleteArticlePriceListOutRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            ArticlePriceListOut result = await _articlePriceListOutRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _articlePriceListOutRespository.Update(result);
            int modifiedRecords = await _articlePriceListOutRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _articlePriceListOutMapper.Map(result);
        }

        public async Task<ArticlePriceListOutResponse> EditArticlePriceListOutAsync(EditArticlePriceListOutRequest request)
        {
            ArticlePriceListOut existingRecord = await _articlePriceListOutRespository.GetAsync(request.Id);

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

            ArticlePriceListOut entity = _articlePriceListOutMapper.Map(request);
            ArticlePriceListOut result = _articlePriceListOutRespository.Update(entity);

            int modifiedRecords = await _articlePriceListOutRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _articlePriceListOutMapper.Map(result);
        }

        public async Task<ArticlePriceListOutResponse> GetArticlePriceListOutAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            ArticlePriceListOut entity = await _articlePriceListOutRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _articlePriceListOutMapper.Map(entity);
        }

        public async Task<IEnumerable<ArticlePriceListOutResponse>> GetArticlePriceListsOutAsync()
        {
            IEnumerable<ArticlePriceListOut> result = await _articlePriceListOutRespository.GetAsync();

            return result.Select(x => _articlePriceListOutMapper.Map(x));
        }

        public IQueryable<ArticlePriceListOutResponse> GetArticlePriceListsOutQuery()
        {
            IQueryable<ArticlePriceListOut> result = _articlePriceListOutRespository.GetQuery();
            return result.Select(x => _articlePriceListOutMapper.Map(x));
        }
    }
}
