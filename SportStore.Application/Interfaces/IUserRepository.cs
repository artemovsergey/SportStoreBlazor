using SportStore.Domen.Models;

namespace SportStore.Application.Interfaces;

public  interface IUserRepository
{

    Task<IEnumerable<User>> GetUsers();
    Task<User> Create(User user);

    Task<User> GetUser(int id);

}
