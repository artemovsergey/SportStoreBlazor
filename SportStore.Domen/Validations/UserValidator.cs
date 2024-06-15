using FluentValidation;
using SportStore.Domen.Models;

namespace SportStore.Domen.Validations;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Name).Length(5).WithMessage("Please enter a name");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Please enter a description");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter a location");
        //RuleFor(x => x.Patronymic).GreaterThan(0).WithMessage("Please enter a length");
        RuleFor(x => x.Login).NotEmpty().WithMessage("Please add a route instruction");
     

        RuleForEach(x => x.Items).SetValidator(new ItemValidator());

        RuleFor(x => x.Items).NotEmpty().WithMessage("Please add a route instruction");

        RuleFor(x => x.Waypoints).NotEmpty().WithMessage("Please add a waypoint");


        Console.WriteLine("Работает валидатор UserValidator!");
    }
}


