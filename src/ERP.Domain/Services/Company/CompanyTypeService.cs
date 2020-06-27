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
    public class CompanyTypeService : ICompanyTypeService
    {
        private readonly ICompanyTypeRespository _companyTypeRespository;
        private readonly ILogger<ICompanyTypeService> _logger;
        private readonly ICompanyTypeMapper _companyTypeMapper;

        public CompanyTypeService(ICompanyTypeRespository companyTypeRespository, ILogger<ICompanyTypeService> logger, ICompanyTypeMapper companyTypeMapper)
        {
            _companyTypeRespository = companyTypeRespository;
            _logger = logger;
            _companyTypeMapper = companyTypeMapper;
        }

        public async Task<CompanyTypeResponse> AddCompanyTypeAsync(AddCompanyTypeRequest request)
        {
            CompanyType companyType = _companyTypeMapper.Map(request);
            CompanyType result = _companyTypeRespository.Add(companyType);

            int modifiedRecords = await _companyTypeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _companyTypeMapper.Map(result);
        }

        public async Task<CompanyTypeResponse> DeleteCompanyTypeAsync(DeleteCompanyTypeRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            CompanyType result = await _companyTypeRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _companyTypeRespository.Update(result);
            int modifiedRecords = await _companyTypeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _companyTypeMapper.Map(result);
        }

        public async Task<CompanyTypeResponse> EditCompanyTypeAsync(EditCompanyTypeRequest request)
        {
            CompanyType existingRecord = await _companyTypeRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            CompanyType entity = _companyTypeMapper.Map(request);
            CompanyType result = _companyTypeRespository.Update(entity);

            int modifiedRecords = await _companyTypeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _companyTypeMapper.Map(result);
        }

        public async Task<CompanyTypeResponse> GetCompanyTypeAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            CompanyType entity = await _companyTypeRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _companyTypeMapper.Map(entity);
        }

        public async Task<IEnumerable<CompanyTypeResponse>> GetCompanyTypesAsync()
        {
            IEnumerable<CompanyType> result = await _companyTypeRespository.GetAsync();

            return result.Select(x => _companyTypeMapper.Map(x));
        }

        public IQueryable<CompanyTypeResponse> GetCompanyTypesQuery()
        {
            IQueryable<CompanyType> result = _companyTypeRespository.GetQuery();
            return result.Select(x => _companyTypeMapper.Map(x));
        }
    }
}
