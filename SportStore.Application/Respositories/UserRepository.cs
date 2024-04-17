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

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _db.Users.ToListAsync();
    }
}
