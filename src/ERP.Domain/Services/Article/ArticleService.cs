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
    public class ArticleService : IArticleService
    {
        private readonly IFAGBinaryRespository _fagBinaryRespository;
        private readonly IFAGTextRespository _fagTextRespository;
        private readonly IArticleRangeRespository _articleRangeRespository;
        private readonly IArticleGroupRespository _articleGroupRespository;
        private readonly IArticleRespository _articleRespository;
        private readonly IArticleTypeRespository _articleTypeRespository;
        private readonly IArticleInventoryRespository _articleInventoryRespository;
        private readonly IArticleMapper _articleMapper;
        private readonly ILogger<IArticleService> _logger;

        public ArticleService(IFAGBinaryRespository fagBinaryRespository, 
            IFAGTextRespository fagTextRespository, 
            IArticleRangeRespository articleRangeRespository, 
            IArticleGroupRespository articleGroupRespository, 
            IArticleRespository articleRespository, 
            IArticleTypeRespository articleTypeRespository, 
            IArticleInventoryRespository articleInventoryRespository, 
            IArticleMapper articleMapper, 
            ILogger<IArticleService> logger)
        {
            _fagBinaryRespository = fagBinaryRespository;
            _fagTextRespository = fagTextRespository;
            _articleRangeRespository = articleRangeRespository;
            _articleGroupRespository = articleGroupRespository;
            _articleRespository = articleRespository;
            _articleTypeRespository = articleTypeRespository;
            _articleInventoryRespository = articleInventoryRespository;
            _articleMapper = articleMapper;
            _logger = logger;
        }

        public async Task<ArticleResponse> AddArticleAsync(AddArticleRequest request)
        {
            Article article = _articleMapper.Map(request);
            Article result = _articleRespository.Add(article);

            int modifiedRecords = await _articleRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _articleMapper.Map(result);
        }

        public async Task<ArticleResponse> DeleteArticleAsync(DeleteArticleRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            Article result = await _articleRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _articleRespository.Update(result);
            int modifiedRecords = await _articleRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _articleMapper.Map(result);
        }

        public async Task<ArticleResponse> EditArticleAsync(EditArticleRequest request)
        {
            Article existingArticle = await _articleRespository.GetAsync(request.Id);

            if (existingArticle == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            if (request.ArticleTypeId != null)
            {
                ArticleType existingType = await _articleTypeRespository.GetAsync(request.ArticleTypeId);
                if (existingType == null)
                {
                    throw new NotFoundException($"ArticleType with {request.ArticleTypeId} is not present");
                }
            }

            if (request.ArticleGroupId != null)
            {
                ArticleGroup existingArticleGroup = await _articleGroupRespository.GetAsync(request.ArticleGroupId);
                if (existingArticleGroup == null)
                {
                    throw new NotFoundException($"ArticleGroup with {request.ArticleGroupId} is not present");
                }
            }

            Article entity = _articleMapper.Map(request);
            Article result = _articleRespository.Update(entity);

            int modifiedRecords = await _articleRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _articleMapper.Map(result);
        }

        public async Task<ArticleResponse> GetArticleAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            Article entity = await _articleRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _articleMapper.Map(entity);
        }

        public async Task<IEnumerable<ArticleResponse>> GetArticlesAsync()
        {
            IEnumerable<Article> result = await _articleRespository.GetAsync();

            return result.Select(x => _articleMapper.Map(x));
        }

        public IQueryable<ArticleResponse> GetArticlesQuery()
        {
            IQueryable<Article> result = _articleRespository.GetQuery();
            return result.Select(x => _articleMapper.Map(x));
        }
    }
}
