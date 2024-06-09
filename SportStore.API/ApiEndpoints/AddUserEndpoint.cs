using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using SportStore.Application.Requests;
using SportStore.Domen.Models;
using SportStore.Infrastructure;
using System.Diagnostics;

namespace SportStore.API.ApiEndpoints;

public class AddUserEndpoint : EndpointBaseAsync.WithRequest<AddUserRequest>.WithActionResult<int>
{
    private readonly SportStoreContext _database;
    public AddUserEndpoint(SportStoreContext database)
    {
        _database = database;
    }


    [HttpPost(AddUserRequest.RouteTemplate)]
    public override async Task<ActionResult<int>>HandleAsync(AddUserRequest request,CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Работает метод Handle из API");
        var user = new User
        {
            Login = request.user.Login,
            Name = request.user.Name,
            Patronymic = request.user.Patronymic,
            Password = request.user.Password,
            Surname = request.user.Surname,
            RoleId = 1
        };

        await _database.Users.AddAsync(user, cancellationToken);

       // var items = request.user.Items.Select(item => new Item
       //{
       //     Number = item.Number,
       //     Title = item.Title
       //});

        //await _database.Items.AddRangeAsync(items, cancellationToken);
        await _database.SaveChangesAsync(cancellationToken);
        return Ok(user.Id);
    }
}


