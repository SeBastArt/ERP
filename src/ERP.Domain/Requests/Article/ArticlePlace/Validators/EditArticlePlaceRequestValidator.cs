using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class EditArticlePlaceRequestValidator : AbstractValidator<EditArticlePlaceRequest>
    {
        public EditArticlePlaceRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.CompanyId).NotEmpty();
            RuleFor(x => x.ReservedQty).NotEmpty();
            RuleFor(x => x.MinimumQty).NotEmpty();
            RuleFor(x => x.OpoQty).NotEmpty();
        }
    }
}
