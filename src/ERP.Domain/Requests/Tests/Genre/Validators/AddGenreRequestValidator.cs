using FluentValidation;

namespace ERP.Domain.Requests.Validators
{
    public class AddGenreRequestValidator : AbstractValidator<AddGenreRequest>
    {
        public AddGenreRequestValidator()
        {
            RuleFor(genre => genre.GenreDescription).NotEmpty();
        }
    }
}