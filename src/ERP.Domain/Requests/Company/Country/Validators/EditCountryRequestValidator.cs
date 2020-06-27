using FluentValidation;

namespace ERP.Domain.Requests.Validation
{
    public class EditCountryRequestValidator : AbstractValidator<EditCountryRequest>
    {
        public EditCountryRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Iso3cc).NotEmpty();
            RuleFor(x => x.Iso2cc).NotEmpty();
            RuleFor(x => x.IsoNumerical).NotEmpty();
            RuleFor(x => x.EconomicArea).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
        }
    }
}
