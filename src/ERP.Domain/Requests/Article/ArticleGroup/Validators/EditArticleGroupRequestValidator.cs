using FluentValidation;

namespace ERP.Domain.Requests.Validation
{
    public class EditArticleGroupRequestValidator : AbstractValidator<EditArticleGroupRequest>
    {
        public EditArticleGroupRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
