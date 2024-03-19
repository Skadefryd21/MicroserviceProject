using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "defaultName";

        [Required]
        public string Publisher { get; set; } = "defaultPublisher";
        
        [Required]
        public string Cost { get; set; } = "defaultCost";

    }
}