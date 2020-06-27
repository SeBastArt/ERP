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
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRespository _documentRespository;
        private readonly ILogger<IDocumentService> _logger;
        private readonly IDocumentMapper _documentMapper;
        private readonly IFAGTextRespository _fagTextRespository;
        private readonly IPersonRespository _personRespository;
        private readonly ICompanyRespository _addressRespository;

        public DocumentService(
            IDocumentRespository documentRespository, 
            ILogger<IDocumentService> logger, 
            IDocumentMapper documentMapper, 
            IFAGTextRespository fagTextRespository, 
            IPersonRespository personRespository, 
            ICompanyRespository addressRespository)
        {
            _documentRespository = documentRespository;
            _logger = logger;
            _documentMapper = documentMapper;
            _fagTextRespository = fagTextRespository;
            _personRespository = personRespository;
            _addressRespository = addressRespository;
        }

        public async Task<DocumentResponse> AddDocumentAsync(AddDocumentRequest request)
        {
            Document document = _documentMapper.Map(request);
            Document result = _documentRespository.Add(document);

            int modifiedRecords = await _documentRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _documentMapper.Map(result);
        }

        public async Task<DocumentResponse> DeleteDocumentAsync(DeleteDocumentRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            Document result = await _documentRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _documentRespository.Update(result);
            int modifiedRecords = await _documentRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _documentMapper.Map(result);
        }

        public async Task<DocumentResponse> EditDocumentAsync(EditDocumentRequest request)
        {
            Document existingRecord = await _documentRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            if (request.TextStartId != null)
            {
                FAGText existingTextStart = await _fagTextRespository.GetAsync((Guid)request.TextStartId);
                if (existingTextStart == null)
                {
                    throw new NotFoundException($"TextStart with {request.TextStartId} is not present");
                }
            }

            if (request.TextHeadId != null)
            {
                FAGText existingTextHead = await _fagTextRespository.GetAsync((Guid)request.TextHeadId);
                if (existingTextHead == null)
                {
                    throw new NotFoundException($"TextHead with {request.TextHeadId} is not present");
                }
            }

            if (request.TextPaymentTermsId != null)
            {
                FAGText existingTextPaymentTerms = await _fagTextRespository.GetAsync((Guid)request.TextPaymentTermsId);
                if (existingTextPaymentTerms == null)
                {
                    throw new NotFoundException($"TextPaymentTerms with {request.TextPaymentTermsId} is not present");
                }
            }

            if (request.TextDeliveryId != null)
            {
                FAGText existingTextDelivery = await _fagTextRespository.GetAsync((Guid)request.TextDeliveryId);
                if (existingTextDelivery == null)
                {
                    throw new NotFoundException($"TextDelivery with {request.TextDeliveryId} is not present");
                }
            }

            if (request.TextEndId != null)
            {
                FAGText existingTextEnd = await _fagTextRespository.GetAsync((Guid)request.TextEndId);
                if (existingTextEnd == null)
                {
                    throw new NotFoundException($"TextEnd with {request.TextEndId} is not present");
                }
            }

            if (request.DocumentPersonId != null)
            {
                Person existingDocumentPerson = await _personRespository.GetAsync((Guid)request.DocumentPersonId);
                if (existingDocumentPerson == null)
                {
                    throw new NotFoundException($"DocumentPerson with {request.DocumentPersonId} is not present");
                }
            }

            if (request.DocumentCompanyId != null)
            {
                Company existingDocumentCompany = await _addressRespository.GetAsync((Guid)request.DocumentCompanyId);
                if (existingDocumentCompany == null)
                {
                    throw new NotFoundException($"DocumentCompany with {request.DocumentCompanyId} is not present");
                }
            }

            if (request.DeliveryPersonId != null)
            {
                Person existingDeliveryPerson = await _personRespository.GetAsync((Guid)request.DeliveryPersonId);
                if (existingDeliveryPerson == null)
                {
                    throw new NotFoundException($"DeliveryPerson with {request.DeliveryPersonId} is not present");
                }
            }

            if (request.DeliveryCompanyId != null)
            {
                Company existingDeliveryCompany = await _addressRespository.GetAsync((Guid)request.DeliveryCompanyId);
                if (existingDeliveryCompany == null)
                {
                    throw new NotFoundException($"DeliveryCompany with {request.DeliveryCompanyId} is not present");
                }
            }

            if (request.InvoicePersonId != null)
            {
                Person existingInvoicePerson = await _personRespository.GetAsync((Guid)request.InvoicePersonId);
                if (existingInvoicePerson == null)
                {
                    throw new NotFoundException($"InvoicePerson with {request.InvoicePersonId} is not present");
                }
            }

            if (request.InvoiceCompanyId != null)
            {
                Company existingInvoiceCompany = await _addressRespository.GetAsync((Guid)request.InvoiceCompanyId);
                if (existingInvoiceCompany == null)
                {
                    throw new NotFoundException($"InvoiceCompany with {request.InvoiceCompanyId} is not present");
                }
            }

            Document entity = _documentMapper.Map(request);
            Document result = _documentRespository.Update(entity);

            int modifiedRecords = await _documentRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _documentMapper.Map(result);
        }

        public async Task<DocumentResponse> GetDocumentAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            Document entity = await _documentRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _documentMapper.Map(entity);
        }

        public async Task<IEnumerable<DocumentResponse>> GetDocumentsAsync()
        {
            IEnumerable<Document> result = await _documentRespository.GetAsync();

            return result.Select(x => _documentMapper.Map(x));
        }

        public IQueryable<DocumentResponse> GetDocumentsQuery()
        {
            IQueryable<Document> result = _documentRespository.GetQuery();
            return result.Select(x => _documentMapper.Map(x));
        }
    }
}
