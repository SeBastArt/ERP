using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class AddArticleRangeRequestValidator : AbstractValidator<AddArticleRangeRequest>
    {
        public AddArticleRangeRequestValidator()
        {
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.NetPrice).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.ArticlePriceListInId).NotEmpty();
            RuleFor(x => x.ArticlePriceListOutId).NotEmpty();
        }
    }
}
