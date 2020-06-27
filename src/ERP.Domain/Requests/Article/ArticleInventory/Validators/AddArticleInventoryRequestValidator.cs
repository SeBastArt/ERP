using FluentValidation;

namespace ERP.Domain.Requests.Article.ArticleInventory.Validators
{
    internal class AddArticleInventoryRequestValidator : AbstractValidator<AddArticleInventoryRequest>
    {
        public AddArticleInventoryRequestValidator()
        {
            RuleFor(x => x.ArticleId).NotEmpty();
            RuleFor(x => x.ArticlePlaceId).NotEmpty();
        }
    }
}
