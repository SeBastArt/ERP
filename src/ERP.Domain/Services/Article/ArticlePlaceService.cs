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
    public class ArticlePlaceService : IArticlePlaceService
    {
        private readonly IArticlePlaceRespository _articlePlaceRespository;
        private readonly ICompanyRespository _companyRespository;
        private readonly ILogger<IArticlePlaceService> _logger;
        private readonly IArticlePlaceMapper _articlePlaceMapper;

        public ArticlePlaceService(IArticlePlaceRespository articlePlaceRespository, 
            ICompanyRespository companyRespository, 
            ILogger<IArticlePlaceService> logger, 
            IArticlePlaceMapper articlePlaceMapper)
        {
            _articlePlaceRespository = articlePlaceRespository;
            _companyRespository = companyRespository;
            _logger = logger;
            _articlePlaceMapper = articlePlaceMapper;
        }

        public async Task<ArticlePlaceResponse> AddArticlePlaceAsync(AddArticlePlaceRequest request)
        {
            ArticlePlace articlePlace = _articlePlaceMapper.Map(request);
            ArticlePlace result = _articlePlaceRespository.Add(articlePlace);

            int modifiedRecords = await _articlePlaceRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _articlePlaceMapper.Map(result);
        }

        public async Task<ArticlePlaceResponse> DeleteArticlePlaceAsync(DeleteArticlePlaceRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            ArticlePlace result = await _articlePlaceRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _articlePlaceRespository.Update(result);
            int modifiedRecords = await _articlePlaceRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _articlePlaceMapper.Map(result);
        }

        public async Task<ArticlePlaceResponse> EditArticlePlaceAsync(EditArticlePlaceRequest request)
        {
            ArticlePlace existingRecord = await _articlePlaceRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            if (request.CompanyId != null)
            {
                Company existingCompany = await _companyRespository.GetAsync(request.CompanyId);
                if (existingCompany == null)
                {
                    throw new NotFoundException($"Company with {request.CompanyId} is not present");
                }
            }

            ArticlePlace entity = _articlePlaceMapper.Map(request);
            ArticlePlace result = _articlePlaceRespository.Update(entity);

            int modifiedRecords = await _articlePlaceRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _articlePlaceMapper.Map(result);
        }

        public async Task<ArticlePlaceResponse> GetArticlePlaceAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            ArticlePlace entity = await _articlePlaceRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _articlePlaceMapper.Map(entity);
        }

        public async Task<IEnumerable<ArticlePlaceResponse>> GetArticlePlacesAsync()
        {
            IEnumerable<ArticlePlace> result = await _articlePlaceRespository.GetAsync();

            return result.Select(x => _articlePlaceMapper.Map(x));
        }

        public IQueryable<ArticlePlaceResponse> GetArticlePlacesQuery()
        {
            IQueryable<ArticlePlace> result = _articlePlaceRespository.GetQuery();
            return result.Select(x => _articlePlaceMapper.Map(x));
        }
    }
}
