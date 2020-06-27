using FluentValidation;

namespace ERP.Domain.Requests.Validation
{
    internal class EditCompanyRequestValidator : AbstractValidator<EditCompanyRequest>
    {
        public EditCompanyRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
