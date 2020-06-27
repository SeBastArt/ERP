using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class AddFAGTextRequestValidator : AbstractValidator<AddFAGTextRequest>
    {
        public AddFAGTextRequestValidator()
        {
            RuleFor(x => x.Iso2cc).Length(2).NotEmpty();
            RuleFor(x => x.Iso3cc).Length(3).NotEmpty();
            RuleFor(x => x.Text).NotEmpty();
            RuleFor(x => x.TextRTF).NotEmpty();
        }
    }
}
