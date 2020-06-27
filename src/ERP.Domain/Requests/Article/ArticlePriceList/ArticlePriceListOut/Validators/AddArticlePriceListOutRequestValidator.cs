using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class AddArticlePriceListOutRequestValidator : AbstractValidator<AddArticlePriceListOutRequest>
    {
        public AddArticlePriceListOutRequestValidator()
        {
            RuleFor(x => x.ScaleUnitQty).NotEmpty();
            RuleFor(x => x.ScaleUnitType).NotEmpty();
            RuleFor(x => x.UnitOrder).NotEmpty();
            RuleFor(x => x.MinOrderQty).NotEmpty();
            RuleFor(x => x.IsMultipleOrderQty).NotEmpty();
            RuleFor(x => x.Priority).NotEmpty();
            RuleFor(x => x.ReorderTime).NotEmpty();
            RuleFor(x => x.ArticleId).NotEmpty();
        }
    }
}
