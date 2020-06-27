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
    public class FAGBinaryService : IFAGBinaryService
    {
        private readonly IFAGBinaryRespository _fagBinaryRespository;
        private readonly ILogger<IFAGBinaryService> _logger;
        private readonly IFAGBinaryMapper _fagBinaryMapper;

        public FAGBinaryService(IFAGBinaryRespository fagBinaryRespository, ILogger<IFAGBinaryService> logger, IFAGBinaryMapper fagBinaryMapper)
        {
            _fagBinaryRespository = fagBinaryRespository;
            _logger = logger;
            _fagBinaryMapper = fagBinaryMapper;
        }

        public async Task<FAGBinaryResponse> AddFAGBinaryAsync(AddFAGBinaryRequest request)
        {
            FAGBinary fagBinary = _fagBinaryMapper.Map(request);
            FAGBinary result = _fagBinaryRespository.Add(fagBinary);

            int modifiedRecords = await _fagBinaryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _fagBinaryMapper.Map(result);
        }

        public async Task<FAGBinaryResponse> DeleteFAGBinaryAsync(DeleteFAGBinaryRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            FAGBinary result = await _fagBinaryRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            _fagBinaryRespository.Update(result);
            int modifiedRecords = await _fagBinaryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _fagBinaryMapper.Map(result);
        }

        public async Task<FAGBinaryResponse> EditFAGBinaryAsync(EditFAGBinaryRequest request)
        {
            FAGBinary existingRecord = await _fagBinaryRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            FAGBinary entity = _fagBinaryMapper.Map(request);
            FAGBinary result = _fagBinaryRespository.Update(entity);

            int modifiedRecords = await _fagBinaryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _fagBinaryMapper.Map(result);
        }

        public async Task<FAGBinaryResponse> GetFAGBinaryAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            FAGBinary entity = await _fagBinaryRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _fagBinaryMapper.Map(entity);
        }

        public async Task<IEnumerable<FAGBinaryResponse>> GetFAGBinariesAsync()
        {
            IEnumerable<FAGBinary> result = await _fagBinaryRespository.GetAsync();

            return result.Select(x => _fagBinaryMapper.Map(x));
        }

        public IQueryable<FAGBinaryResponse> GetFAGBinariesQuery()
        {
            IQueryable<FAGBinary> result = _fagBinaryRespository.GetQuery();
            return result.Select(x => _fagBinaryMapper.Map(x));
        }
    }
}
