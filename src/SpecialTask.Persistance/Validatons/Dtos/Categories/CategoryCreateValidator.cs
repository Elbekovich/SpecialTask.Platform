using FluentValidation;
using SpecialTask.Persistance.Dtos.Categories;

namespace SpecialTask.Persistance.Validatons.Dtos.Categories;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().NotNull().WithMessage("Name field is required!")
        .MinimumLength(3).WithMessage("Name must be more than 3 characters")
        .MaximumLength(20).WithMessage("Name must be less than 20 characters");
    }
}
