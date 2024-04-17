using Microsoft.EntityFrameworkCore;
using SportStore.Application.Interfaces;
using SportStore.Domen.Models;
using SportStore.Infrastructure;

namespace SportStore.Application.Respositories;

public class UserRepository : IUserRepository
{
    private readonly SportStoreContext _db;

    public UserRepository(SportStoreContext db)
    {
        _db = db;
    }

    public async Task<User> Create(User user)
    {
        try
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.InnerException.Message}");
        }

        return new User();

    }

    public async Task<User> GetUser(int id)
    {
        return await _db.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _db.Users.Include(u => u.Role).ToListAsync();
    }
}
