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
    public class ArticleGroupService : IArticleGroupService
    {
        private readonly IArticleGroupRespository _articleGroupRespository;
        private readonly ILogger<IArticleGroupService> _logger;
        private readonly IArticleGroupMapper _articleGroupMapper;

        public ArticleGroupService(IArticleGroupRespository articleGroupRespository, ILogger<IArticleGroupService> logger, IArticleGroupMapper articleGroupMapper)
        {
            _articleGroupRespository = articleGroupRespository;
            _logger = logger;
            _articleGroupMapper = articleGroupMapper;
        }

        public async Task<ArticleGroupResponse> AddArticleGroupAsync(AddArticleGroupRequest request)
        {
            ArticleGroup articleGroup = _articleGroupMapper.Map(request);
            ArticleGroup result = _articleGroupRespository.Add(articleGroup);

            int modifiedRecords = await _articleGroupRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _articleGroupMapper.Map(result);
        }

        public async Task<ArticleGroupResponse> DeleteArticleGroupAsync(DeleteArticleGroupRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            ArticleGroup result = await _articleGroupRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _articleGroupRespository.Update(result);
            int modifiedRecords = await _articleGroupRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _articleGroupMapper.Map(result);
        }

        public async Task<ArticleGroupResponse> EditArticleGroupAsync(EditArticleGroupRequest request)
        {
            ArticleGroup existingRecord = await _articleGroupRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            ArticleGroup entity = _articleGroupMapper.Map(request);
            ArticleGroup result = _articleGroupRespository.Update(entity);

            int modifiedRecords = await _articleGroupRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _articleGroupMapper.Map(result);
        }

        public async Task<ArticleGroupResponse> GetArticleGroupAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            ArticleGroup entity = await _articleGroupRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _articleGroupMapper.Map(entity);
        }

        public async Task<IEnumerable<ArticleGroupResponse>> GetArticleGroupsAsync()
        {
            IEnumerable<ArticleGroup> result = await _articleGroupRespository.GetAsync();

            return result.Select(x => _articleGroupMapper.Map(x));
        }

        public IQueryable<ArticleGroupResponse> GetArticleGroupsQuery()
        {
            IQueryable<ArticleGroup> result = _articleGroupRespository.GetQuery();
            return result.Select(x => _articleGroupMapper.Map(x));
        }
    }
}
