using FluentValidation;

namespace ERP.Domain.Requests.Validation
{
    public class AddCompanyTypeRequestValidator : AbstractValidator<AddCompanyTypeRequest>
    {
        public AddCompanyTypeRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
        }
    }
}
