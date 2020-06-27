using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    internal class EditArticleInventoryRequestValidator : AbstractValidator<EditArticleInventoryRequest>
    {
        public EditArticleInventoryRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ArticleId).NotEmpty();
            RuleFor(x => x.ArticlePlaceId).NotEmpty();
        }
    }
}
