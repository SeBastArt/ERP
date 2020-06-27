using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class AddFAGBinaryRequestValidator : AbstractValidator<AddFAGBinaryRequest>
    {
        public AddFAGBinaryRequestValidator()
        {
            RuleFor(x => x.FileName).NotEmpty();
        }
    }
}
