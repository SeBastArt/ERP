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
    public class CountryService : ICountryService
    {
        private readonly ICountryRespository _countryRespository;
        private readonly ILogger<ICountryService> _logger;
        private readonly ICountryMapper _countryMapper;

        public CountryService(ICountryRespository countryRespository, ILogger<ICountryService> logger, ICountryMapper countryMapper)
        {
            _countryRespository = countryRespository;
            _logger = logger;
            _countryMapper = countryMapper;
        }

        public async Task<CountryResponse> AddCountryAsync(AddCountryRequest request)
        {
            Country country = _countryMapper.Map(request);
            Country result = _countryRespository.Add(country);

            int modifiedRecords = await _countryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _countryMapper.Map(result);
        }

        public async Task<CountryResponse> DeleteCountryAsync(DeleteCountryRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            Country result = await _countryRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _countryRespository.Update(result);
            int modifiedRecords = await _countryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _countryMapper.Map(result);
        }

        public async Task<CountryResponse> EditCountryAsync(EditCountryRequest request)
        {
            Country existingRecord = await _countryRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            Country entity = _countryMapper.Map(request);
            Country result = _countryRespository.Update(entity);

            int modifiedRecords = await _countryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _countryMapper.Map(result);
        }

        public async Task<CountryResponse> GetCountryAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            Country entity = await _countryRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _countryMapper.Map(entity);
        }

        public async Task<IEnumerable<CountryResponse>> GetCountriesAsync()
        {
            IEnumerable<Country> result = await _countryRespository.GetAsync();

            return result.Select(x => _countryMapper.Map(x));
        }

        public IQueryable<CountryResponse> GetCountriesQuery()
        {
            IQueryable<Country> result = _countryRespository.GetQuery();
            return result.Select(x => _countryMapper.Map(x));
        }
    }
}
