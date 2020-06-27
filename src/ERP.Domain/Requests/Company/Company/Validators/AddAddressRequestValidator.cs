using FluentValidation;

namespace ERP.Domain.Requests.Validation
{
    public class AddCompanyRequestValidator : AbstractValidator<AddCompanyRequest>
    {
        public AddCompanyRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
