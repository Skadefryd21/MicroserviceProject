using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        //This constructor accepts an instance of DbContextOptions<AppDbContext> as a parameter. This parameter typically contains configuration options for the DbContext, such as connection string, database provider, etc.
        //The constructor passes these options to the base class constructor using base(opt). 
        //This is necessary because the DbContext base class requires these options to properly initialize the context.
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        //This property represents a collection of Platform entities within the database. It allows you to query and manipulate the Platform entities using LINQ queries or Entity Framework methods like Add, Remove, Find, etc.
        public DbSet<Platform> Platforms { get; set; }
    }
}