using MediatR;
using SportStore.Domen.Models;

namespace SportStore.Application.Requests;

public record GetUsersRequest() : IRequest<GetUsersRequest.Response>
{
    public const string RouteTemplate = "api/users";
    
    public record Request(int id);
    public record Response(IEnumerable<User> Users);
}
