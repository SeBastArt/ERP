using FluentValidation;

namespace ERP.Domain.Requests.Validation
{
    public class EditPersonRequestValidator : AbstractValidator<EditPersonRequest>
    {
        public EditPersonRequestValidator()
        {
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Sex).NotEmpty();
            RuleFor(x => x.Department).NotEmpty();
            RuleFor(x => x.PhoneOffice).NotEmpty();
            RuleFor(x => x.PhonePrivate).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PictureId).NotEmpty();
        }
    }
}
