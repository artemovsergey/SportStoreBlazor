using Microsoft.AspNetCore.Mvc;
using SportStore.Application.Respositories;
using SportStore.Domen.Models;

namespace SportStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserRepository _repo;

    public UsersController(UserRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _repo.GetUsers());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser([FromRoute] int id)
    {
        return Ok(await _repo.GetUser(id));
    }

    [HttpPost]
    public async Task<IActionResult> PostUser([FromBody] User user)
    {

        //valid

        if(user == null)
        {
            return BadRequest("user equals null");
        }

        await _repo.Create(user);
    
        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }



    // POST api/User/checklogin
    [HttpPost("checklogin")]
    public IActionResult CheckName([FromBody] string name)
    {
        if (name == "admin")
            return BadRequest("login not allowed");

        return Ok(name);
        //return name == "admin" ? BadRequest("admin") : Ok();
    }


}
