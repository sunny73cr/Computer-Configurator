namespace ComputerConfigurator.Api.Part
{
    public abstract class Part
    {
        public Guid UUID { get; set; }
        public Guid ManufacturerUUID { get; set; }
        public string Model { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string? LongDescription { get; set; }
        public decimal Price { get; set; }

        public virtual Manufacturer.Manufacturer Manufacturer { get; set; } = null!;

        public Part()
        {

        }

        public Part(DTO.Create part)
        {
            UUID = part.UUID;
            ManufacturerUUID = part.ManufacturerUUID;
            Model = part.Model;
            ShortDescription = part.ShortDescription;
            LongDescription = part.LongDescription;
            Price = part.Price;
        }

        public Part(Guid uuid, Guid manufacturerUUID, string model, string shortDescription, string? longDescription, decimal price, Manufacturer.Manufacturer manufacturer)
        {
            UUID = uuid;
            ManufacturerUUID = manufacturerUUID;
            Model = model;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            Price = price;
            Manufacturer = manufacturer;
        }

        protected static void Edit(Part part, DTO.Edit edits)
        {
            if (part.ManufacturerUUID != edits.ManufacturerUUID) part.ManufacturerUUID = edits.ManufacturerUUID;
            if (part.Model != edits.Model) part.Model = edits.Model;
            if (part.ShortDescription != edits.ShortDescription) part.ShortDescription = edits.ShortDescription;
            if (part.LongDescription != edits.LongDescription) part.LongDescription = edits.LongDescription;
            if (part.Price != edits.Price) part.Price = edits.Price;
        }
    }
}
