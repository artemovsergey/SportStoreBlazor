using Microsoft.AspNetCore.Mvc;

namespace SportStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok();
    }

}
