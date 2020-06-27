using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class EditDocumentPositionRequestValidator : AbstractValidator<EditDocumentPositionRequest>
    {
        public EditDocumentPositionRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.PositionNumberText).NotEmpty();
            RuleFor(x => x.PositionType).NotEmpty();
            RuleFor(x => x.ArticleNameExtern).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.ScaleUnitQty).NotEmpty();
            RuleFor(x => x.ScaleUnitType).NotEmpty();
            RuleFor(x => x.ScaleUnit).NotEmpty();
            RuleFor(x => x.DeliveryQty).NotEmpty();
            RuleFor(x => x.IsPartialDelivered).NotEmpty();
            RuleFor(x => x.PriceBase).NotEmpty();
            RuleFor(x => x.PricePerUnit).NotEmpty();
            RuleFor(x => x.PriceTotal).NotEmpty();
            RuleFor(x => x.SalesTaxPercent).NotEmpty();
            RuleFor(x => x.ParentId).NotEmpty();
            RuleFor(x => x.DocumentId).NotEmpty();
            RuleFor(x => x.ArticleId).NotEmpty();
        }
    }
}
