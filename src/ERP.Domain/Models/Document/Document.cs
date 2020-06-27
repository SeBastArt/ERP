using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    public class Document : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("address_text_document", TypeName = "varchar(max)")]
        public string CompanyTextDocument { get; set; }

        [Column("address_text_delivery", TypeName = "varchar(max)")]
        public string CompanyTextDelivery { get; set; }

        [Column("address_text_invoice", TypeName = "varchar(max)")]
        public string CompanyTextInvoice { get; set; }

        [Column("number", TypeName = "varchar(max)")]
        public string Number { get; set; }

        [Column("type")]
        public int DocumentType { get; set; }

        [Column("sub_type")]
        public int SubType { get; set; }

        [Column("type_name", TypeName = "varchar(max)")]
        public string TypeName { get; set; }

        [Column("value_basis")]
        public int ValueBias { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("print_date")]
        public DateTime PrintDate { get; set; }

        [Column("reminder_date")]
        public DateTime ReminderDate { get; set; }

        [Column("print_count")]
        public int PrintCount { get; set; }

        [Column("price_sum_net", TypeName = "decimal (38,20)")]
        public decimal NetPriceSum { get; set; }

        [Column("price_gross", TypeName = "decimal (38,20)")]
        public decimal PriceGross { get; set; }

        [Column("is_archive")]
        public bool IsArchived { get; set; }

        [Column("fk_text_start")]
        public Guid? TextStartId { get; set; }

        public FAGText TextStart { get; set; }

        [Column("fk_text_head")]
        public Guid? TextHeadId { get; set; }

        public FAGText TextHead { get; set; }

        [Column("fk_text_paymentterms")]
        public Guid? TextPaymentTermsId { get; set; }

        public FAGText TextPaymentTerms { get; set; }

        [Column("fk_text_delivery")]
        public Guid? TextDeliveryId { get; set; }

        public FAGText TextDelivery { get; set; }

        [Column("fk_text_end")]
        public Guid? TextEndId { get; set; }

        public FAGText TextEnd { get; set; }

        [Column("fk_person")]
        public Guid? DocumentPersonId { get; set; }

        public Person DocumentPerson { get; set; }

        [Column("fk_address")]
        public Guid? DocumentCompanyId { get; set; }

        public Company DocumentCompany { get; set; }

        [Column("fk_delivery_person")]
        public Guid? DeliveryPersonId { get; set; }

        public Person DeliveryPerson { get; set; }

        [Column("fk_delivery_address")]
        public Guid? DeliveryCompanyId { get; set; }

        public Company DeliveryCompany { get; set; }

        [Column("fk_invoice_person")]
        public Guid? InvoicePersonId { get; set; }

        public Person InvoicePerson { get; set; }

        [Column("fk_invoice_address")]
        public Guid? InvoiceCompanyId { get; set; }

        [ForeignKey("fk_invoice_address")]
        public Company InvoiceCompany { get; set; }
    }
}

