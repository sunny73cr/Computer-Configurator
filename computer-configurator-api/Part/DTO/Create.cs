namespace ComputerConfigurator.Api.Part.DTO
{
    public abstract class Create
    {
        public Guid UUID { get; } = Guid.NewGuid();
        public Guid ManufacturerUUID { get; set; }
        public string Model { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string? LongDescription { get; set; }
        public decimal Price { get; set; }

        public abstract IReadOnlyList<string> Validate();
    }
}
