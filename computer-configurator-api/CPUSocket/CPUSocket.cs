namespace ComputerConfigurator.Api.CPUSocket
{
    public class CPUSocket
    {
        public Guid UUID { get; set; }
        public string Version { get; set; } = string.Empty;

        public CPUSocket()
        {

        }

        public CPUSocket(DTO.Create cpuSocket)
        {
            UUID = cpuSocket.UUID;
            Version = cpuSocket.Version;
        }
    }
}
