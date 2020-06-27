using FluentValidation;

namespace ERP.Domain.Requests.Validation
{
    public class AddArticleRequestValidator : AbstractValidator<EditArticleRequest>
    {
        public AddArticleRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.MaterialType).NotEmpty();
            RuleFor(x => x.IsArchived).NotEmpty();
            RuleFor(x => x.IsDiscontinued).NotEmpty();
            RuleFor(x => x.IsBatch).NotEmpty();
            RuleFor(x => x.IsMultistock).NotEmpty();
            RuleFor(x => x.IsProvisionEnabled).NotEmpty();
            RuleFor(x => x.IsDisposition).NotEmpty();
            RuleFor(x => x.IsCasting).NotEmpty();
            RuleFor(x => x.ArticleGroupId).NotEmpty();
            RuleFor(x => x.ArticleTypeId).NotEmpty();
            RuleFor(x => x.ItemNumber).NotEmpty();
        }
    }
}
