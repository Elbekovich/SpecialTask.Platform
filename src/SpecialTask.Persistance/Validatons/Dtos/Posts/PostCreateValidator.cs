using FluentValidation;
using SpecialTask.Persistance.Dtos.Posts;

namespace SpecialTask.Persistance.Validatons.Dtos.Posts
{
    public class PostCreateValidator : AbstractValidator<PostCreateDto>
    {
        public PostCreateValidator()
        {
            RuleFor(dto => dto.CategoryId).NotEmpty().WithMessage("Category id is required!");

            RuleFor(dto => dto.UserId).NotEmpty().WithMessage("User id is required!");

            RuleFor(dto => dto.Title).NotEmpty().NotNull().WithMessage("Title is required!")
                .MaximumLength(20).WithMessage("Title length lass be than 20 characters")
                .MinimumLength(3).WithMessage("Title lenght must ber than 3 characters");

            RuleFor(dto => dto.Price).NotEmpty().WithMessage("Price is required!");

            RuleFor(dto => dto.Description).NotEmpty().NotNull().WithMessage("Description is required!")
                .MaximumLength(20).WithMessage("Description length lass be than 20 characters")
                .MinimumLength(3).WithMessage("Description lenght must ber than 3 characters");

            RuleFor(dto => dto.Region).NotEmpty().NotNull().WithMessage("Region is required!")
                .MaximumLength(20).WithMessage("Region length lass be than 20 characters")
                .MinimumLength(3).WithMessage("Region lenght must ber than 3 characters");

            RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneValidator.IsValid(phone))
                .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

            RuleFor(dto => dto.Price).Must(price => PriceValidator.IsValid(price))
                .WithMessage("You entered the wrong price length or entered a negative number!");
        }
    }
}
