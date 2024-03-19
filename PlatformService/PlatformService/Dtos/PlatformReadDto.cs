namespace PlatformService.Dtos
{
    public class PlatformReadDto
    {

        public int Id { get; set; }

        public string Name { get; set; } = "defaultName";

        public string Publisher { get; set; } = "defaultPublisher";

        public string Cost { get; set; } = "defaultCost";

    }
}