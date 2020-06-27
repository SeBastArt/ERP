using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class EditArticleRangeRequestValidator : AbstractValidator<EditArticleRangeRequest>
    {
        public EditArticleRangeRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.NetPrice).NotEmpty();
            RuleFor(x => x.Discount).NotEmpty();
            RuleFor(x => x.Addition).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.ArticlePriceListInId).NotEmpty();
            RuleFor(x => x.ArticlePriceListOutId).NotEmpty();
        }
    }
}
