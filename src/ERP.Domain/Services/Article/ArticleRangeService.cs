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
    public class ArticleRangeService : IArticleRangeService
    {
        private readonly IArticleRangeRespository _articleRangeRespository;
        private readonly ILogger<IArticleRangeService> _logger;
        private readonly IArticleRangeMapper _articleRangeMapper;

        public ArticleRangeService(IArticleRangeRespository articleRangeRespository, ILogger<IArticleRangeService> logger, IArticleRangeMapper articleRangeMapper)
        {
            _articleRangeRespository = articleRangeRespository;
            _logger = logger;
            _articleRangeMapper = articleRangeMapper;
        }

        public async Task<ArticleRangeResponse> AddArticleRangeAsync(AddArticleRangeRequest request)
        {
            ArticleRange articleRange = _articleRangeMapper.Map(request);
            ArticleRange result = _articleRangeRespository.Add(articleRange);

            int modifiedRecords = await _articleRangeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _articleRangeMapper.Map(result);
        }

        public async Task<ArticleRangeResponse> DeleteArticleRangeAsync(DeleteArticleRangeRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            ArticleRange result = await _articleRangeRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _articleRangeRespository.Update(result);
            int modifiedRecords = await _articleRangeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _articleRangeMapper.Map(result);
        }

        public async Task<ArticleRangeResponse> EditArticleRangeAsync(EditArticleRangeRequest request)
        {
            ArticleRange existingRecord = await _articleRangeRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            ArticleRange entity = _articleRangeMapper.Map(request);
            ArticleRange result = _articleRangeRespository.Update(entity);

            int modifiedRecords = await _articleRangeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _articleRangeMapper.Map(result);
        }

        public async Task<ArticleRangeResponse> GetArticleRangeAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            ArticleRange entity = await _articleRangeRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _articleRangeMapper.Map(entity);
        }

        public async Task<IEnumerable<ArticleRangeResponse>> GetArticleRangesAsync()
        {
            IEnumerable<ArticleRange> result = await _articleRangeRespository.GetAsync();

            return result.Select(x => _articleRangeMapper.Map(x));
        }

        public IQueryable<ArticleRangeResponse> GetArticleRangesQuery()
        {
            IQueryable<ArticleRange> result = _articleRangeRespository.GetQuery();
            return result.Select(x => _articleRangeMapper.Map(x));
        }
    }
}
