using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlatformService.Data;
using PlatformService.Models;

namespace PlatformRepoTest;

public class PlatformRepoTest
{
    private readonly AppDbContext _context;
    public PlatformRepoTest()
    {
        DbContextOptionsBuilder<AppDbContext> optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString()); //Use guid to not use the same database for all tests

        _context = new AppDbContext(optionsBuilder.Options);
    }

    [Fact]
    public void PlatformRepo_CreatePlatform_ReturnTrue()
    {
        //Arrange
        var repo = new PlatformRepo(_context);
        var platform = new Platform{
            Id = 1,
            Name = "Microsoft SQL Server",
            Publisher = "Microsoft",
            Cost = "Free"
        };
        //Act
        bool result = repo.CreatePlatform(platform);
        //Assert
        var platforms = _context.Platforms.ToList();
        Assert.True(result);
    }
}