using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SportStore.Application.Requests;
using SportStore.Infrastructure;
using System.Diagnostics;

namespace SportStore.API.ApiEndpoints;

public class UploadUserImageEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<string>
{
    private readonly SportStoreContext _database;
    public UploadUserImageEndpoint(SportStoreContext database)
    {
        _database = database;
    }

    [HttpPost(UploadUserImageRequest.RouteTemplate)]
    public override async Task<ActionResult<string>> HandleAsync([FromRoute] int UserId, CancellationToken cancellationToken = default)
    {
        var User = await _database.Users.SingleOrDefaultAsync(x => x.Id == UserId,cancellationToken);
        if (User is null)
        {
            return BadRequest("User does not exist.");
        }
        var file = Request.Form.Files[0];
        if (file.Length == 0)
        {
            return BadRequest("No image found.");
        }
        var filename = $"{Guid.NewGuid()}.jpg";
        var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);
        var resizeOptions = new ResizeOptions
        {
            Mode = ResizeMode.Pad,
            Size = new Size(640, 426)
        };
        using var image = Image.Load(file.OpenReadStream());
        image.Mutate(x => x.Resize(resizeOptions));
        await image.SaveAsJpegAsync(saveLocation,cancellationToken: cancellationToken);

        if (!string.IsNullOrWhiteSpace(User.Image))
        {
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", User.Image));
        }

        User.Image = filename;
        await _database.SaveChangesAsync(cancellationToken);
        return Ok(User.Image);
    }
}
