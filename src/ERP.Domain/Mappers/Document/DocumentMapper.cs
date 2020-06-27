using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class DocumentMapper : IDocumentMapper
    {
        private readonly IPersonMapper _personMapper;
        private readonly ICompanyMapper _addressMapper;
        private readonly IFAGTextMapper _fagTextMapper;

        public DocumentMapper(IPersonMapper personMapper, ICompanyMapper addressMapper, IFAGTextMapper fagTextMapper)
        {
            _personMapper = personMapper;
            _addressMapper = addressMapper;
            _fagTextMapper = fagTextMapper;
        }

        public Document Map(AddDocumentRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Document document = new Document
            {
                CompanyTextDocument = request.CompanyTextDocument,
                CompanyTextDelivery = request.CompanyTextDelivery,
                CompanyTextInvoice = request.CompanyTextInvoice,
                Number = request.Number,
                DocumentType = request.DocumentType,
                SubType = request.SubType,
                TypeName = request.TypeName,
                ValueBias = request.ValueBias,
                Status = request.Status,
                PrintDate = request.PrintDate,
                ReminderDate = request.ReminderDate,
                PrintCount = request.PrintCount,
                NetPriceSum = request.NetPriceSum,
                PriceGross = request.PriceGross,
                IsArchived = request.IsArchived,
                TextStartId = request.TextStartId,
                TextHeadId = request.TextHeadId,
                TextPaymentTermsId = request.TextPaymentTermsId,
                TextDeliveryId = request.TextDeliveryId,
                TextEndId = request.TextEndId,
                DocumentPersonId = request.DocumentPersonId,
                DocumentCompanyId = request.DocumentCompanyId,
                DeliveryPersonId = request.DeliveryPersonId,
                DeliveryCompanyId = request.DeliveryCompanyId,
                InvoicePersonId = request.InvoicePersonId,
                InvoiceCompanyId = request.InvoiceCompanyId,
                
            };

            return document;
        }

        public Document Map(EditDocumentRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Document document = new Document
            {
                Id = request.Id,
                CompanyTextDocument = request.CompanyTextDocument,
                CompanyTextDelivery = request.CompanyTextDelivery,
                CompanyTextInvoice = request.CompanyTextInvoice,
                Number = request.Number,
                DocumentType = request.DocumentType,
                SubType = request.SubType,
                TypeName = request.TypeName,
                ValueBias = request.ValueBias,
                Status = request.Status,
                PrintDate = request.PrintDate,
                ReminderDate = request.ReminderDate,
                PrintCount = request.PrintCount,
                NetPriceSum = request.NetPriceSum,
                PriceGross = request.PriceGross,
                IsArchived = request.IsArchived,
                TextStartId = request.TextStartId,
                TextHeadId = request.TextHeadId,
                TextPaymentTermsId = request.TextPaymentTermsId,
                TextDeliveryId = request.TextDeliveryId,
                TextEndId = request.TextEndId,
                DocumentPersonId = request.DocumentPersonId,
                DocumentCompanyId = request.DocumentCompanyId,
                DeliveryPersonId = request.DeliveryPersonId,
                DeliveryCompanyId = request.DeliveryCompanyId,
                InvoicePersonId = request.InvoicePersonId,
                InvoiceCompanyId = request.InvoiceCompanyId,
            };

            return document;
        }

        public DocumentResponse Map(Document document)
        {
            if (document == null)
            {
                return null;
            };

            DocumentResponse response = new DocumentResponse
            {
                Id = document.Id,
                CompanyTextDocument = document.CompanyTextDocument,
                CompanyTextDelivery = document.CompanyTextDelivery,
                CompanyTextInvoice = document.CompanyTextInvoice,
                Number = document.Number,
                DocumentType = document.DocumentType,
                SubType = document.SubType,
                TypeName = document.TypeName,
                ValueBias = document.ValueBias,
                Status = document.Status,
                PrintDate = document.PrintDate,
                ReminderDate = document.ReminderDate,
                PrintCount = document.PrintCount,
                NetPriceSum = document.NetPriceSum,
                PriceGross = document.PriceGross,
                IsArchived = document.IsArchived,

                TextStartId = (Guid)document.TextStartId,
                TextStart = _fagTextMapper.Map(document.TextStart),
                TextHeadId = (Guid)document.TextHeadId,
                TextHead = _fagTextMapper.Map(document.TextHead),
                TextPaymentTermsId = (Guid)document.TextPaymentTermsId,
                TextPaymentTerms = _fagTextMapper.Map(document.TextPaymentTerms),
                TextDeliveryId = (Guid)document.TextDeliveryId,
                TextDelivery = _fagTextMapper.Map(document.TextDelivery),
                TextEndId = (Guid)document.TextEndId,
                TextEnd = _fagTextMapper.Map(document.TextEnd),

                DocumentPersonId = (Guid)document.DocumentPersonId,
                DocumentPerson = _personMapper.Map(document.DocumentPerson),
                DocumentCompanyId = (Guid)document.DocumentCompanyId,
                DocumentCompany = _addressMapper.Map(document.DocumentCompany),
                DeliveryPersonId = (Guid)document.DeliveryPersonId,
                DeliveryPerson = _personMapper.Map(document.DeliveryPerson),
                DeliveryCompanyId = (Guid)document.DeliveryCompanyId,
                DeliveryCompany = _addressMapper.Map(document.DeliveryCompany),
                InvoicePersonId = (Guid)document.InvoicePersonId,
                InvoicePerson = _personMapper.Map(document.InvoicePerson),
                InvoiceCompanyId = (Guid)document.InvoiceCompanyId,
                InvoiceCompany = _addressMapper.Map(document.InvoiceCompany),
            };
            return response;
        }

        public IQueryable<DocumentResponse> Map(IQueryable<Document> document)
        {

            if (document == null)
            {
                return null;
            };

            IQueryable<DocumentResponse> response = document.Select(x => new DocumentResponse()
            {
                Id = x.Id,
                CompanyTextDocument = x.CompanyTextDocument,
                CompanyTextDelivery = x.CompanyTextDelivery,
                CompanyTextInvoice = x.CompanyTextInvoice,
                Number = x.Number,
                DocumentType = x.DocumentType,
                SubType = x.SubType,
                TypeName = x.TypeName,
                ValueBias = x.ValueBias,
                Status = x.Status,
                PrintDate = x.PrintDate,
                ReminderDate = x.ReminderDate,
                PrintCount = x.PrintCount,
                NetPriceSum = x.NetPriceSum,
                PriceGross = x.PriceGross,
                IsArchived = x.IsArchived,

                TextStartId = (Guid)x.TextStartId,
                TextStart = _fagTextMapper.Map(x.TextStart),
                TextHeadId = (Guid)x.TextHeadId,
                TextHead = _fagTextMapper.Map(x.TextHead),
                TextPaymentTermsId = (Guid)x.TextPaymentTermsId,
                TextPaymentTerms = _fagTextMapper.Map(x.TextPaymentTerms),
                TextDeliveryId = (Guid)x.TextDeliveryId,
                TextDelivery = _fagTextMapper.Map(x.TextDelivery),
                TextEndId = (Guid)x.TextEndId,
                TextEnd = _fagTextMapper.Map(x.TextEnd),

                DocumentPersonId = (Guid)x.DocumentPersonId,
                DocumentPerson = _personMapper.Map(x.DocumentPerson),
                DocumentCompanyId = (Guid)x.DocumentCompanyId,
                DocumentCompany = _addressMapper.Map(x.DocumentCompany),
                DeliveryPersonId = (Guid)x.DeliveryPersonId,
                DeliveryPerson = _personMapper.Map(x.DeliveryPerson),
                DeliveryCompanyId = (Guid)x.DeliveryCompanyId,
                DeliveryCompany = _addressMapper.Map(x.DeliveryCompany),
                InvoicePersonId = (Guid)x.InvoicePersonId,
                InvoicePerson = _personMapper.Map(x.InvoicePerson),
                InvoiceCompanyId = (Guid)x.InvoiceCompanyId,
                InvoiceCompany = _addressMapper.Map(x.InvoiceCompany),
            });

            return response;
        }
    }
}
