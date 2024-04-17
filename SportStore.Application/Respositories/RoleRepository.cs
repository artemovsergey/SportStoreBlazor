using Microsoft.EntityFrameworkCore;
using SportStore.Application.Interfaces;
using SportStore.Domen.Models;
using SportStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Application.Respositories
{
    public class RoleRepository : IRoleRepository
    {

        private readonly SportStoreContext _db;

        public RoleRepository(SportStoreContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _db.Role.ToListAsync();
        }
    }
}
