namespace ComputerConfigurator.Api.RAMSocket.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Version { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(RAMSocket RAMSocket)
        {
            UUID = RAMSocket.UUID;
            Version = RAMSocket.Version;
        }
    }
}
