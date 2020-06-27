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
    public class FAGTextService : IFAGTextService
    {
        private readonly IFAGTextRespository _fagTextRespository;
        private readonly ILogger<IFAGTextService> _logger;
        private readonly IFAGTextMapper _fagTextMapper;

        public FAGTextService(IFAGTextRespository fagTextRespository, ILogger<IFAGTextService> logger, IFAGTextMapper fagTextMapper)
        {
            _fagTextRespository = fagTextRespository;
            _logger = logger;
            _fagTextMapper = fagTextMapper;
        }

        public async Task<FAGTextResponse> AddFAGTextAsync(AddFAGTextRequest request)
        {
            FAGText fagText = _fagTextMapper.Map(request);
            FAGText result = _fagTextRespository.Add(fagText);

            int modifiedRecords = await _fagTextRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _fagTextMapper.Map(result);
        }

        public async Task<FAGTextResponse> DeleteFAGTextAsync(DeleteFAGTextRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            FAGText result = await _fagTextRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            _fagTextRespository.Update(result);
            int modifiedRecords = await _fagTextRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _fagTextMapper.Map(result);
        }

        public async Task<FAGTextResponse> EditFAGTextAsync(EditFAGTextRequest request)
        {
            FAGText existingRecord = await _fagTextRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            FAGText entity = _fagTextMapper.Map(request);
            FAGText result = _fagTextRespository.Update(entity);

            int modifiedRecords = await _fagTextRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _fagTextMapper.Map(result);
        }

        public async Task<FAGTextResponse> GetFAGTextAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            FAGText entity = await _fagTextRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _fagTextMapper.Map(entity);
        }

        public async Task<IEnumerable<FAGTextResponse>> GetFAGTextsAsync()
        {
            IEnumerable<FAGText> result = await _fagTextRespository.GetAsync();

            return result.Select(x => _fagTextMapper.Map(x));
        }

        public IQueryable<FAGTextResponse> GetFAGTextsQuery()
        {
            IQueryable<FAGText> result = _fagTextRespository.GetQuery();
            return result.Select(x => _fagTextMapper.Map(x));
        }
    }
}
