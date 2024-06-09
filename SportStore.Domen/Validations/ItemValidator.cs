using FluentValidation;
using SportStore.Domen.Models;

namespace SportStore.Domen.Validations;

public class ItemValidator : AbstractValidator<Item>
{
    public ItemValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Please enter a stage");
        RuleFor(x => x.Number).NotEmpty().WithMessage("Please enter a description");
    }
}
