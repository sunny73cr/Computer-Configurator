namespace ComputerConfigurator.Api.RadiatorSize.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public int Size { get; set; }

        public Details()
        {

        }

        public Details(RadiatorSize RadiatorSize)
        {
            UUID = RadiatorSize.UUID;
            Size = RadiatorSize.Size;
        }
    }
}
