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
    public class CompanyService : ICompanyService
    {
        private readonly IFAGBinaryRespository _fagBinaryRespository;
        private readonly IFAGTextRespository _fagTextRespository;
        private readonly ICompanyTypeRespository _companyTypeRespository;
        private readonly ICountryRespository _countryRespository;
        private readonly ICompanyRespository _companyRespository;
        private readonly ICompanyMapper _companyMapper;
        private readonly ILogger<ICompanyService> _logger;

        public CompanyService(
            IFAGBinaryRespository fagBinaryRespository,
            IFAGTextRespository fagTextRespository,
            ICompanyTypeRespository companyTypeRespository,
            ICountryRespository countryRespository,
            ICompanyRespository companyRespository,
            ICompanyMapper companyMapper,
            ILogger<ICompanyService> logger)
        {
            _fagBinaryRespository = fagBinaryRespository;
            _fagTextRespository = fagTextRespository;
            _companyTypeRespository = companyTypeRespository;
            _countryRespository = countryRespository;
            _companyRespository = companyRespository;
            _companyMapper = companyMapper;
            _logger = logger;
        }

        public async Task<CompanyResponse> AddCompanyAsync(AddCompanyRequest request)
        {
            Company address = _companyMapper.Map(request);
            Company result = _companyRespository.Add(address);

            int modifiedRecords = await _companyRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _companyMapper.Map(result);
        }

        public async Task<CompanyResponse> DeleteCompanyAsync(DeleteCompanyRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            Company result = await _companyRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _companyRespository.Update(result);
            int modifiedRecords = await _companyRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _companyMapper.Map(result);
        }

        public async Task<CompanyResponse> EditCompanyAsync(EditCompanyRequest request)
        {
            Company existingRecord = await _companyRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            if (request.ParentId != null)
            {
                Company existingParent = await _companyRespository.GetAsync(request.ParentId);
                if (existingParent == null)
                {
                    throw new NotFoundException($"Parent with {request.ParentId} is not present");
                }
            }

            CompanyType existingCompanyType = await _companyTypeRespository.GetAsync(request.CompanyTypeId);
            if (existingCompanyType == null)
            {
                throw new NotFoundException($"CompanyType with {request.CompanyTypeId} is not present");
            }

            Country existingCountry = await _countryRespository.GetAsync(request.CountryId);
            if (existingCountry == null)
            {
                throw new NotFoundException($"Country with {request.CountryId} is not present");
            }

            if (request.LogoId != null)
            {
                FAGBinary existingFAGBinary = await _fagBinaryRespository.GetAsync(request.LogoId);
                if (existingFAGBinary == null)
                {
                    throw new NotFoundException($"Logo with {request.LogoId} is not present");
                }
            }

            Company entity = _companyMapper.Map(request);
            Company result = _companyRespository.Update(entity);

            int modifiedRecords = await _companyRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _companyMapper.Map(result);
        }

        public async Task<CompanyResponse> GetCompanyAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            Company entity = await _companyRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _companyMapper.Map(entity);
        }

        public async Task<IEnumerable<CompanyResponse>> GetCompaniesAsync()
        {
            IEnumerable<Company> result = await _companyRespository.GetAsync();

            return result.Select(x => _companyMapper.Map(x));
        }

        public IQueryable<CompanyResponse> GetCompaniesQuery()
        {
            IQueryable<Company> result = _companyRespository.GetQuery();
            return result.Select(x => _companyMapper.Map(x));
        }
    }
}
