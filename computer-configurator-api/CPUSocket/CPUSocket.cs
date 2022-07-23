namespace ComputerConfigurator.Api.CPUSocket
{
    public class CPUSocket
    {
        public Guid UUID { get; set; }
        public string Version { get; set; } = null!;

        public CPUSocket()
        {

        }

        public CPUSocket(DTO.Create cpuSocket)
        {
            UUID = cpuSocket.UUID;
            Version = cpuSocket.Version;
        }

        public static void Edit(CPUSocket cpusocket, DTO.Edit edits)
        {
            if (cpusocket.Version != edits.Version) cpusocket.Version = edits.Version;
        }
    }
}
