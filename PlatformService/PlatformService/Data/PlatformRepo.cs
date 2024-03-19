using Microsoft.AspNetCore.Server.IIS.Core;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        //Dependancy Injection
        private readonly AppDbContext _context;
        
        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Add(platform);
            return true;
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            Platform? result = _context.Platforms.FirstOrDefault(p => p.Id == id);
            
            if ( result == null)
                throw new ArgumentNullException(nameof(id));

            else
                return result;
        }
            

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}