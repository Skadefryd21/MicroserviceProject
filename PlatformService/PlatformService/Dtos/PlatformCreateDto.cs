using System.ComponentModel.DataAnnotations;

namespace PlatformService.Data
{
    public class PlatformCreateDto
    {
        [Required]
        public string Name { get; set; } = "defaultName";
        [Required]
        public string Publisher { get; set; } = "defaultPublisher";
        [Required]
        public string Cost { get; set; } = "defaultCost";
    }
}