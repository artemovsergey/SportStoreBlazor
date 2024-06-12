using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStore.Application.Requests;
using SportStore.Infrastructure;

namespace SportStore.API.ApiEndpoints;

public class GetUserEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetUserRequest.Response>
{
    private readonly SportStoreContext _context;
    public GetUserEndpoint(SportStoreContext context)
    {
        _context = context;
    }

    [HttpGet(GetUserRequest.RouteTemplate)]
    public override async Task<ActionResult<GetUserRequest.Response>> HandleAsync([FromRoute]int Id, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.Include(x => x.Items).SingleOrDefaultAsync(x => x.Id == Id,cancellationToken: cancellationToken);
        if (user is null)
        {
            return BadRequest($"Пользователь с id = {Id} не найден.");
        }

        return Ok(user);
    }
}
