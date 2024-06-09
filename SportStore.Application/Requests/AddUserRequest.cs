using FluentValidation.Validators;
using FluentValidation;
using MediatR;
using SportStore.Domen.Models;
using SportStore.Domen.Validations;

namespace SportStore.Application.Requests;

public record AddUserRequest(User user) : IRequest<AddUserRequest.Response>
{
    public const string RouteTemplate = "api/users";
    public record Response(int userId);
}
public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
{
    public AddUserRequestValidator()
    {
        RuleFor(x => x.user).SetValidator(new UserValidator());
    }
}
