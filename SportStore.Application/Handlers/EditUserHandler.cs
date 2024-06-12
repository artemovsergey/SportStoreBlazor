using MediatR;
using SportStore.Application.Requests;
using System.Net.Http.Json;

namespace SportStore.Application.Handlers;

public class EditUserHandler : IRequestHandler<EditUserRequest, EditUserRequest.Response>
{
    private readonly HttpClient _httpClient;
    public EditUserHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<EditUserRequest.Response> Handle(EditUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PutAsJsonAsync(EditUserRequest.RouteTemplate,request, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return new EditUserRequest.Response(true);
        }
        else
        {
            return new EditUserRequest.Response(false);
        }
    }
}
