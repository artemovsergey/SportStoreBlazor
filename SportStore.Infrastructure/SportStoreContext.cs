using Microsoft.EntityFrameworkCore;
using SportStore.Domen.Models;

namespace SportStore.Infrastructure;

public  class SportStoreContext : DbContext
{

    public DbSet<User> Users { get; set; }

    public SportStoreContext()
    {
        Database.EnsureCreated();    
    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SportStoreBlazor;Trusted_Connection=True;");
    }
}


