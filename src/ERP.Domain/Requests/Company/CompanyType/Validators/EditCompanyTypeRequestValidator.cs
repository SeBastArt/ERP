using FluentValidation;

namespace ERP.Domain.Requests.Validation
{
    public class EditCompanyTypeRequestValidator : AbstractValidator<EditCompanyTypeRequest>
    {
        public EditCompanyTypeRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
