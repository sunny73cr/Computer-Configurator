namespace ComputerConfigurator.Api.Part.DTO
{
    public abstract class Details
    {
        public const string SQLParameters = "";

        public Guid UUID { get; set; }
        public Guid ManufacturerUUID { get; set; }
        public string Model { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string? LongDescription { get; set; }
        public decimal Price { get; set; }

        public Details()
        {

        }

        public Details(Part part)
        {
            UUID = part.UUID;
            ManufacturerUUID = part.ManufacturerUUID;
            Model = part.Model;
            ShortDescription = part.ShortDescription;
            LongDescription = part.LongDescription;
            Price = part.Price;
        }

        public Details(DTO.Details part)
        {
            UUID = part.UUID;
            ManufacturerUUID = part.ManufacturerUUID;
            Model = part.Model;
            ShortDescription = part.ShortDescription;
            LongDescription = part.LongDescription;
            Price = part.Price;
        }
    }
}
