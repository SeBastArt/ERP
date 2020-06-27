using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    internal class AddArticlePlaceRequestValidator : AbstractValidator<AddArticlePlaceRequest>
    {
        public AddArticlePlaceRequestValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty();
            RuleFor(x => x.ReservedQty).NotEmpty();
            RuleFor(x => x.MinimumQty).NotEmpty();
            RuleFor(x => x.OpoQty).NotEmpty();
        }
    }
}
