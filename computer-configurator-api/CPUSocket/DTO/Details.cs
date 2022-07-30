namespace ComputerConfigurator.Api.CPUSocket.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Version { get; set; } = string.Empty;

        public Details(CPUSocket cpuSocket)
        {
            UUID = cpuSocket.UUID;
            Version = cpuSocket.Version;
        }
    }
}
