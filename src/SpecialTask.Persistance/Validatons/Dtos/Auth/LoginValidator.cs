using FluentValidation;
using SpecialTask.Persistance.Dtos.Auth;

namespace SpecialTask.Persistance.Validatons.Dtos.Auth
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneValidator.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

            RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
                .WithMessage("Password is not strong password!");
        }
    }
}
