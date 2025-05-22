using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApiPizushi.Data;
using WebApiPizushi.Models.Category;

namespace WebApiPizushi.Validators.Category;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateModel>
{
    public CategoryCreateValidator(AppDbPizushiContext db)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Назва є обов'язковою")
            .MustAsync(async (name, cancellation) =>
                    !await db.Categories.AnyAsync(c => c.Name == name, cancellation))
            .WithMessage("Категорія з такою назвою вже існує")
            .MaximumLength(250)
            .WithMessage("Назва повинна містити не більше 250 символів");
        RuleFor(x => x.Slug)
            .NotEmpty()
            .WithMessage("Слаг є обов'язковим")
            .MaximumLength(250)
            .WithMessage("Слаг повинен містити не більше 250 символів");
        RuleFor(x => x.ImageFile)
            //.NotNull().WithMessage("Файл зображення є обов'язковим")
            .NotEmpty().WithMessage("Файл зображення є обов'язковим");
        //.Must(file => file!.Length > 0)
        //.WithMessage("Файл не повинен бути порожнім");
    }
}
