using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

//namespace PlatformService.Data
// #pragma warning disable CS8604 // Possible null reference argument.
// {
//     //Static class so no constructor dependancy injection
//     public static class PrepDb
    // {
//         public static void PrepPopulation(IApplicationBuilder app, bool isProducion)
//         {
//             //Injecting the app services into "serviceScope" since It's the only time this class will be instantiated
//             using( IServiceScope serviceScope = app.ApplicationServices.CreateScope())
//             {
//                 //Gets AppDbContext service from "serviceScope.ServiceProvidor"
//                 SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProducion);
//             }
//         }

//         private static void SeedData(AppDbContext context, bool isProducion)
//         {
//             if(isProducion)
//             {
//                 Console.WriteLine("--> Attempting to apply migrations...");
//                 try
//                 {
//                     context.Database.Migrate();
//                 }
//                 catch (Exception ex)
//                 {
//                     Console.WriteLine($"--> Could not run: {ex.Message}");
//                 }

//             }

//             //Check if there is any data
//             if(context.Platforms.Any()){
//                 Console.WriteLine("--> We already have Data. . .");
//             }
//             else{
//                 Console.WriteLine("--> Seeding Data. . .");

//                 context.Platforms.AddRange(
//                     new Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free"},
//                     new Platform() {Name="SQL Server Express", Publisher="Microsoft", Cost="Free"},
//                     new Platform() {Name="Kubernetes", Publisher="Cloud Native Computing Foundation", Cost="Free"}
//                 );

//                 context.SaveChanges();
//             }
//         }
//     }
// }