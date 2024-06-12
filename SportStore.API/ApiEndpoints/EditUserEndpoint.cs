using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStore.Application.Requests;
using SportStore.Domen.Models;
using SportStore.Infrastructure;

namespace SportStore.API.ApiEndpoints;

public class EditUserEndpoint : EndpointBaseAsync.WithRequest<EditUserRequest>.WithActionResult<bool>
{
    private readonly SportStoreContext _database;
    public EditUserEndpoint(SportStoreContext database)
    {
        _database = database;
    }

    [HttpPut(EditUserRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditUserRequest request, CancellationToken cancellationToken = default)
    {
        var User = await _database.Users.Include(x => x.Items).SingleOrDefaultAsync(x => x.Id == request.user.Id,cancellationToken: cancellationToken);
        if (User is null)
        {
            Console.WriteLine("User could not be found.");
            return BadRequest("User could not be found.");
        }

        User.Name = request.user.Name;
        User.Surname = request.user.Surname;
        User.Patronymic = request.user.Patronymic;
        User.Login = request.user.Login;
        User.Password = request.user.Password;
        User.Items = request.user.Items.Select(ri => new Item
          {
              Number = ri.Number,
              Title = ri.Title,
         
          }).ToList();
        User.RoleId = 1;

        if (request.user.ImageAction == ImageAction.Remove)
        {
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images",User.Image!));
            User.Image = null;
        }
        await _database.SaveChangesAsync(cancellationToken);
        return Ok(true);
    }
}