using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class AddArticlePriceListInValidator : AbstractValidator<AddArticlePriceListInRequest>
    {
        public AddArticlePriceListInValidator()
        {
            RuleFor(x => x.ScaleUnitQty).NotEmpty();
            RuleFor(x => x.ScaleUnitType).NotEmpty();
            RuleFor(x => x.UnitOrder).NotEmpty();
            RuleFor(x => x.MinOrderQty).NotEmpty();
            RuleFor(x => x.IsMultipleOrderQty).NotEmpty();
            RuleFor(x => x.ValidFrom).NotEmpty();
            RuleFor(x => x.Validto).NotEmpty();
            RuleFor(x => x.ArticleId).NotEmpty();
        }
    }
}
