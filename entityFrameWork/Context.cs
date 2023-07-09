using Microsoft.EntityFrameworkCore;
using programm.Entities;

namespace programm;

public class Context : DbContext
{

    public Context()
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=lfybk2000;database=test;", 
            new MySqlServerVersion(new Version(8, 0, 22)));
    }
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Sponsor> Sponsors { get; set; }

    

}