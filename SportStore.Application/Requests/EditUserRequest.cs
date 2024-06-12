using FluentValidation;
using MediatR;
using SportStore.Domen.Models;
using SportStore.Domen.Validations;

namespace SportStore.Application.Requests;

public record EditUserRequest(User user) : IRequest<EditUserRequest.Response>
{
    public const string RouteTemplate = "/api/Users";
    public record Response(bool IsSuccess);
}
public class EditUserRequestValidator : AbstractValidator<EditUserRequest>
{
    public EditUserRequestValidator()
    {
        RuleFor(x => x.user).SetValidator(new UserValidator());
    }
}
