using FirstMediatr.Model;
using FluentValidation;

namespace FirstMediatr.Validator
{
    public class LibraryMemberValidator : AbstractValidator<LibraryMember>
    {
        public LibraryMemberValidator()
        {
            RuleFor(c => c.Name).NotEmpty()
                .MaximumLength(100)
                .NotNull();

            RuleFor(c => c.KnowledgeLevel).InclusiveBetween(1, 10);

            RuleFor(c => c.FavouriteBook).NotNull();

            RuleFor(c => c.FavouriteCategory).IsInEnum();

            RuleFor(c => c.HatedCategory).IsInEnum()
                .WithMessage("Hated category must come from an enum collection.");

            RuleFor(c => c.WearingGlasses).NotNull();

            RuleFor(c => c.Age).GreaterThanOrEqualTo(1);

            RuleFor(c => c.MemberCardNumber).MinimumLength(13)
                .MaximumLength(16);

            RuleForEach(c => c.ReadedBooks).NotEmpty()
                .SetValidator(new BookValidator());

            RuleFor(c => c.RandomValue).Must(AreYouLucky)
                .WithMessage("Oops! You are out of luck! Try again.");
        }

        private bool AreYouLucky(int randomValue)
        {
            Random random = new();
            return (random.Next(1, 10) + randomValue) % 2 == 0;
        }
    }
}
