using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStore.Application.Requests;
using SportStore.Domen.Models;
using SportStore.Infrastructure;

namespace SportStore.API.ApiEndpoints;

public class GetUsersEndpoint : EndpointBaseAsync.WithRequest<int>
                                                 .WithActionResult<IEnumerable<User>>
{
    private readonly SportStoreContext _database;
    public GetUsersEndpoint(SportStoreContext database)
    {
        _database = database;
    }

    [HttpGet(GetUsersRequest.RouteTemplate)]
    public override async Task<ActionResult<IEnumerable<User>>> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Работает метод Handle из API");

        return Ok(await _database.Users.ToListAsync());
    }
}
