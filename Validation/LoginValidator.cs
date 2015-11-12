using FluentValidation;
using SmartFlow.ViewModels;

namespace SmartFlow.Validation
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Please enter a username");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter a password");
        }
    }
}