using MediatR;
using SportStore.Domen.Models;

namespace SportStore.Application.Requests;

public record GetUserRequest(int Id) : IRequest<GetUserRequest.Response>
{
    public const string RouteTemplate = "/api/users/{Id}";
    public record Response(User user);
}
