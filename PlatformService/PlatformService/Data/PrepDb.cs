using PlatformService.Models;

namespace PlatformService.Data
#pragma warning disable CS8604 // Possible null reference argument.
{
    //Static class so no constructor dependancy injection
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            //Injecting the app services into "serviceScope" since It's the only time this class will be instantiated
            using( IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                //Gets AppDbContext service from "serviceScope.ServiceProvidor"
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            //Check if there is any data
            if(context.Platforms.Any()){
                Console.WriteLine("--> We already have Data. . .");
            }
            else{
                Console.WriteLine("--> Seeding Data. . .");

                context.Platforms.AddRange(
                    new Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="SQL Server Express", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="Kubernetes", Publisher="Cloud Native Computing Foundation", Cost="Free"}
                );

                context.SaveChanges();
            }
        }
    }
}