using SportStore.Domen.Models;

namespace SportStore.Application.Interfaces;

public  interface IRoleRepository
{

    Task<IEnumerable<Role>> GetRoles();


}
