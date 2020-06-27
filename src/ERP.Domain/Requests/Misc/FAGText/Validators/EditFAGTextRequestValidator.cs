using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class EditFAGTextRequestValidator : AbstractValidator<EditFAGTextRequest>
    {
        public EditFAGTextRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Iso2cc).Length(2).NotEmpty();
            RuleFor(x => x.Iso3cc).Length(3).NotEmpty();
            RuleFor(x => x.Text).NotEmpty();
            RuleFor(x => x.TextRTF).NotEmpty();
        }
    }
}
