namespace ComputerConfigurator.Api.CPUSocket.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Version { get; set; } = null!;

        public Details(CPUSocket cpuSocket)
        {
            UUID = cpuSocket.UUID;
            Version = cpuSocket.Version;
        }
    }
}
