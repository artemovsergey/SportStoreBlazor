using Microsoft.EntityFrameworkCore;
using SportStore.Domen.Models;

namespace SportStore.Infrastructure;

public  class SportStoreContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Item> Items { get; set; }



    public SportStoreContext()
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();    
    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SportStoreBlazor;Trusted_Connection=True;");
    }
}


