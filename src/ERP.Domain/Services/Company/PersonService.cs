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
    public class PersonService : IPersonService
    {
        private readonly IPersonRespository _personRespository;
        private readonly ILogger<IPersonService> _logger;
        private readonly IPersonMapper _personMapper;
        private readonly IFAGBinaryRespository _fagBinaryRespository;

        public PersonService(IPersonRespository personRespository, ILogger<IPersonService> logger, IPersonMapper personMapper, IFAGBinaryRespository fagBinaryRespository)
        {
            _personRespository = personRespository;
            _logger = logger;
            _personMapper = personMapper;
            _fagBinaryRespository = fagBinaryRespository;
        }

        public async Task<PersonResponse> AddPersonAsync(AddPersonRequest request)
        {
            Person person = _personMapper.Map(request);
            Person result = _personRespository.Add(person);

            int modifiedRecords = await _personRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _personMapper.Map(result);
        }

        public async Task<PersonResponse> DeletePersonAsync(DeletePersonRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            Person result = await _personRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _personRespository.Update(result);
            int modifiedRecords = await _personRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _personMapper.Map(result);
        }

        public async Task<PersonResponse> EditPersonAsync(EditPersonRequest request)
        {
            Person existingRecord = await _personRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            if (request.PictureId != null)
            {
                FAGBinary existingPicture = await _fagBinaryRespository.GetAsync(request.PictureId);
                if (existingPicture == null)
                {
                    throw new NotFoundException($"Picture with {request.PictureId} is not present");
                }
            }

            Person entity = _personMapper.Map(request);
            Person result = _personRespository.Update(entity);

            int modifiedRecords = await _personRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _personMapper.Map(result);
        }

        public async Task<PersonResponse> GetPersonAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            Person entity = await _personRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _personMapper.Map(entity);
        }

        public async Task<IEnumerable<PersonResponse>> GetPersonsAsync()
        {
            IEnumerable<Person> result = await _personRespository.GetAsync();

            return result.Select(x => _personMapper.Map(x));
        }

        public IQueryable<PersonResponse> GetPersonsQuery()
        {
            IQueryable<Person> result = _personRespository.GetQuery();
            return result.Select(x => _personMapper.Map(x));
        }
    }
}
