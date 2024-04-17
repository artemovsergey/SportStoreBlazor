using Microsoft.AspNetCore.Mvc;
using SportStore.Application.Respositories;
using SportStore.Domen.Models;
using System.Threading.Tasks;

namespace SportStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly RoleRepository _repo;

    public RolesController(RoleRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        return Ok(await _repo.GetRoles());
    }


}
