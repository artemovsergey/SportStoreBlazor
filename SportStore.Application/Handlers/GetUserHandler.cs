
using MediatR;
using SportStore.Application.Requests;
using SportStore.Domen.Models;
using System.Net.Http.Json;

namespace SportStore.Application.Handlers;

public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserRequest.Response?>
{
    private readonly HttpClient _httpClient;
    public GetUserHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetUserRequest.Response?> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _httpClient.GetFromJsonAsync<User>(GetUserRequest.RouteTemplate.Replace("{Id}", request.Id.ToString()));
            return new GetUserRequest.Response(user);
            
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("Ошибка запроса!");
            return default!;
        }
    }
}