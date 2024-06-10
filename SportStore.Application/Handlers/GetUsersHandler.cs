using MediatR;
using SportStore.Application.Requests;
using SportStore.Domen.Models;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace SportStore.Application.Handlers;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersRequest.Response>
{
    private readonly HttpClient _httpClient;
    private readonly string BaseUrl = "https://localhost:7214";
    public GetUsersHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<GetUsersRequest.Response> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Работает метод Handle из Handler");
        var response = await _httpClient.GetAsync($"{BaseUrl}/{GetUsersRequest.RouteTemplate}", cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var users = await response.Content.ReadFromJsonAsync<IEnumerable<User>>(cancellationToken: cancellationToken);
            return new GetUsersRequest.Response(users);
        }
        else
        {
            IEnumerable<User> users = new List<User>();
            return new GetUsersRequest.Response(users);
        }
    }
}
