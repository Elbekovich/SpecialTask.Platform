﻿using FluentValidation;
using SpecialTask.Persistance.Dtos.Auth;

namespace SpecialTask.Persistance.Validatons.Dtos.Auth;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname is required!")
        .MaximumLength(20).WithMessage("Firstname must be less than 30 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname is required!")
            .MaximumLength(20).WithMessage("Lastname must be less than 30 characters");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneValidator.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}
