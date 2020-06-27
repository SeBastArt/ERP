using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class EditArticleTypeRequestValidator : AbstractValidator<EditArticleTypeRequest>
    {
        public EditArticleTypeRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.NatureType).NotEmpty();
        }
    }
}
