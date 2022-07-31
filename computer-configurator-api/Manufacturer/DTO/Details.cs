namespace ComputerConfigurator.Api.Manufacturer.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Name { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(Manufacturer manufacturer)
        {
            UUID = manufacturer.UUID;
            Name = manufacturer.Name;
        }
    }
}
