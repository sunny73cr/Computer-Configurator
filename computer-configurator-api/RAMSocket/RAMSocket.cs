namespace ComputerConfigurator.Api.RAMSocket;

public partial class RAMSocket
{
    public Guid UUID { get; set; }
    public string Version { get; set; } = string.Empty;

    public RAMSocket()
    {

    }

    public RAMSocket(DTO.Create RAMSocket)
    {
        UUID = RAMSocket.UUID;
        Version = RAMSocket.Version;
    }

    public static void Edit(RAMSocket RAMSocket, DTO.Edit edits)
    {
        if (RAMSocket.Version != edits.Version) RAMSocket.Version = edits.Version;
    }
}
