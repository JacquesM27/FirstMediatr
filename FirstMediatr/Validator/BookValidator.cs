using FirstMediatr.Model;
using FluentValidation;

namespace FirstMediatr.Validator
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator() 
        { 
            RuleFor(c => c.Id).GreaterThanOrEqualTo(1);
        }
    }
}
