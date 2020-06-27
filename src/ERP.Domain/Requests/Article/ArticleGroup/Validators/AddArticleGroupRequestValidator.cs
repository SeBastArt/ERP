using FluentValidation;

namespace ERP.Domain.Requests.Validation
{
    public class AddArticleGroupRequestValidator : AbstractValidator<AddArticleGroupRequest>
    {
        public AddArticleGroupRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
