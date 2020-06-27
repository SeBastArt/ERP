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
    public class ArticleTypeService : IArticleTypeService
    {
        private readonly IArticleTypeRespository _articleTypeRespository;
        private readonly ILogger<IArticleTypeService> _logger;
        private readonly IArticleTypeMapper _articleTypeMapper;

        public ArticleTypeService(IArticleTypeRespository articleTypeRespository, ILogger<IArticleTypeService> logger, IArticleTypeMapper articleTypeMapper)
        {
            _articleTypeRespository = articleTypeRespository;
            _logger = logger;
            _articleTypeMapper = articleTypeMapper;
        }

        public async Task<ArticleTypeResponse> AddArticleTypeAsync(AddArticleTypeRequest request)
        {
            ArticleType articleType = _articleTypeMapper.Map(request);
            ArticleType result = _articleTypeRespository.Add(articleType);

            int modifiedRecords = await _articleTypeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _articleTypeMapper.Map(result);
        }

        public async Task<ArticleTypeResponse> DeleteArticleTypeAsync(DeleteArticleTypeRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            ArticleType result = await _articleTypeRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _articleTypeRespository.Update(result);
            int modifiedRecords = await _articleTypeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _articleTypeMapper.Map(result);
        }

        public async Task<ArticleTypeResponse> EditArticleTypeAsync(EditArticleTypeRequest request)
        {
            ArticleType existingRecord = await _articleTypeRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            ArticleType entity = _articleTypeMapper.Map(request);
            ArticleType result = _articleTypeRespository.Update(entity);

            int modifiedRecords = await _articleTypeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _articleTypeMapper.Map(result);
        }

        public async Task<ArticleTypeResponse> GetArticleTypeAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            ArticleType entity = await _articleTypeRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _articleTypeMapper.Map(entity);
        }

        public async Task<IEnumerable<ArticleTypeResponse>> GetArticleTypesAsync()
        {
            IEnumerable<ArticleType> result = await _articleTypeRespository.GetAsync();

            return result.Select(x => _articleTypeMapper.Map(x));
        }

        public IQueryable<ArticleTypeResponse> GetArticleTypesQuery()
        {
            IQueryable<ArticleType> result = _articleTypeRespository.GetQuery();
            return result.Select(x => _articleTypeMapper.Map(x));
        }
    }
}
