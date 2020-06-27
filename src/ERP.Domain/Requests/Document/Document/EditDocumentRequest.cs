using System;

namespace ERP.Domain.Requests
{
    public class EditDocumentRequest
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

        public Guid? TextStartId { get; set; }
        public Guid? TextHeadId { get; set; }
        public Guid? TextPaymentTermsId { get; set; }
        public Guid? TextDeliveryId { get; set; }
        public Guid? TextEndId { get; set; }

        public Guid? DocumentPersonId { get; set; }
        public Guid? DocumentCompanyId { get; set; }
        public Guid? DeliveryPersonId { get; set; }
        public Guid? DeliveryCompanyId { get; set; }
        public Guid? InvoicePersonId { get; set; }
        public Guid? InvoiceCompanyId { get; set; }
    }
}
