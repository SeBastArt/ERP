using ERP.Domain.Models;
using System;

namespace ERP.Domain.Responses
{
    public class DocumentResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string CompanyTextDocument { get; set; }
        public string CompanyTextDelivery { get; set; }
        public string CompanyTextInvoice { get; set; }
        public string Number { get; set; }
        public int DocumentType { get; set; }
        public int SubType { get; set; }
        public string TypeName { get; set; }
        public int ValueBias { get; set; }
        public int Status { get; set; }
        public DateTime PrintDate { get; set; }
        public DateTime ReminderDate { get; set; }
        public int PrintCount { get; set; }
        public decimal NetPriceSum { get; set; }
        public decimal PriceGross { get; set; }
        public bool IsArchived { get; set; }

        public Guid TextStartId { get; set; }
        public FAGTextResponse TextStart { get; set; }
        public Guid TextHeadId { get; set; }
        public FAGTextResponse TextHead { get; set; }
        public Guid TextPaymentTermsId { get; set; }
        public FAGTextResponse TextPaymentTerms { get; set; }
        public Guid TextDeliveryId { get; set; }
        public FAGTextResponse TextDelivery { get; set; }
        public Guid TextEndId { get; set; }
        public FAGTextResponse TextEnd { get; set; }

        public Guid DocumentPersonId { get; set; }
        public PersonResponse DocumentPerson { get; set; }
        public Guid DocumentCompanyId { get; set; }
        public CompanyResponse DocumentCompany { get; set; }
        public Guid DeliveryPersonId { get; set; }
        public PersonResponse DeliveryPerson { get; set; }
        public Guid DeliveryCompanyId { get; set; }
        public CompanyResponse DeliveryCompany { get; set; }
        public Guid InvoicePersonId { get; set; }
        public PersonResponse InvoicePerson { get; set; }
        public Guid InvoiceCompanyId { get; set; }
        public CompanyResponse InvoiceCompany { get; set; }
    }
}
