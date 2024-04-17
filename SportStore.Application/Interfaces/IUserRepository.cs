using SportStore.Domen.Models;

namespace SportStore.Application.Interfaces;

public  interface IUserRepository
{

    Task<IEnumerable<User>> GetUsers();

}
