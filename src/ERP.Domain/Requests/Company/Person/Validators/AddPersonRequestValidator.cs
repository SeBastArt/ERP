using FluentValidation;

namespace ERP.Domain.Requests.Validation
{
    public class AddPersonRequestValidator : AbstractValidator<AddPersonRequest>
    {
        public AddPersonRequestValidator()
        {
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Sex).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
