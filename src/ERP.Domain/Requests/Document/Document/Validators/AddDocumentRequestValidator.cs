using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class AddDocumentRequestValidator : AbstractValidator<AddDocumentRequest>
    {
        public AddDocumentRequestValidator()
        {
            RuleFor(x => x.CompanyTextDocument).NotEmpty();
            RuleFor(x => x.CompanyTextDelivery).NotEmpty();
            RuleFor(x => x.CompanyTextInvoice).NotEmpty();
            RuleFor(x => x.Number).NotEmpty();
            RuleFor(x => x.DocumentType).NotEmpty();
            RuleFor(x => x.SubType).NotEmpty();
            RuleFor(x => x.TypeName).NotEmpty();
            RuleFor(x => x.ValueBias).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.PrintDate).NotEmpty();
            RuleFor(x => x.ReminderDate).NotEmpty();
            RuleFor(x => x.PrintCount).NotEmpty();
            RuleFor(x => x.NetPriceSum).NotEmpty();
            RuleFor(x => x.PriceGross).NotEmpty();
            RuleFor(x => x.IsArchived).NotEmpty();
            RuleFor(x => x.DocumentPersonId).NotEmpty();
            RuleFor(x => x.DocumentCompanyId).NotEmpty();
            RuleFor(x => x.DeliveryPersonId).NotEmpty();
            RuleFor(x => x.DeliveryCompanyId).NotEmpty();
            RuleFor(x => x.InvoicePersonId).NotEmpty();
            RuleFor(x => x.InvoiceCompanyId).NotEmpty();
        }
    }
}
