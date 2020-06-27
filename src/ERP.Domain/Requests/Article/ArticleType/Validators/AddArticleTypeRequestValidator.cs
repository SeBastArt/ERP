using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class AddArticleTypeRequestValidator : AbstractValidator<AddArticleTypeRequest>
    {
        public AddArticleTypeRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.NatureType).NotEmpty();
        }
    }
}
