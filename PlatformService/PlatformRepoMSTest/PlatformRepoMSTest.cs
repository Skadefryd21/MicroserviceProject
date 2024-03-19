
using Microsoft.EntityFrameworkCore;
using Moq;
using PlatformService.Data;
using PlatformService.Models;

namespace PlatformRepoMSTest;

[TestClass]
public class PlatformRepoMSTest
{
    [TestMethod]
    public void PlatformRepoMSTest_PlatformRepo_CreatePlatform_True()
    {
        //Arrange
        List<Platform> platforms = new List<Platform>(){
            new Platform{
                Name = "Microsoft SQL Server",
                Publisher = "Microsoft",
                Cost = "Free"
            },
            new Platform{
                Name = "Blender",
                Publisher = "Blender",
                Cost = "Free"
            },
            new Platform{
                Name = "Amazon Web Services",
                Publisher = "Amazon",
                Cost = "200$"
            }
        };

        //Setup Mock dbContext
        var mockdbContext = new Mock<AppDbContext>();
        var mockdbSet = new Mock<DbSet<Platform>>();

        var platformData = platforms.AsQueryable();
        mockdbSet.As<IQueryable<Platform>>().Setup(p => p.Provider).Returns(platformData.Provider);
        mockdbSet.As<IQueryable<Platform>>().Setup(p => p.ElementType).Returns(platformData.ElementType);
        mockdbSet.As<IQueryable<Platform>>().Setup(p => p.Expression).Returns(platformData.Expression);
        mockdbSet.As<IQueryable<Platform>>().Setup(p => p.GetEnumerator()).Returns(() => platforms.GetEnumerator());
        mockdbContext.Setup(x => x.Platforms).Returns(mockdbSet.Object);

        //Act
        IPlatformRepo repository = new PlatformRepo(mockdbContext.Object);
        bool result = repository.CreatePlatform(platforms.FirstOrDefault());

        //Assert
        Assert.IsTrue(result);
    }
}