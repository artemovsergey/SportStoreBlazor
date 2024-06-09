using MediatR;
using SportStore.Application.Requests;
using SportStore.Domen.Models;
using System.Net.Http.Json;

namespace SportStore.Application.Handlers;

public class AddUserHandler : IRequestHandler<AddUserRequest,AddUserRequest.Response>
{
    private readonly HttpClient _httpClient;
    private readonly string BaseUrl = "https://localhost:7214";
    public AddUserHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<AddUserRequest.Response> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Работает метод Handle из Handler");
        var response = await _httpClient.PostAsJsonAsync<AddUserRequest>($"{BaseUrl}/{AddUserRequest.RouteTemplate}", request, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var userId = await response.Content.ReadFromJsonAsync<int>(cancellationToken:cancellationToken);
            return new AddUserRequest.Response(userId);
        }
        else
        {
            return new AddUserRequest.Response(-1);
        }
    }
}
