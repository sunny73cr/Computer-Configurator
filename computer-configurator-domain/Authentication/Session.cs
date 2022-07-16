namespace ComputerConfigurator.Domain.Authentication.Session
{
    public class Session
    {
        public Guid Key { get; }
        public DateTime LoginTimestamp { get; }
        public DateTime? LogoutTimestamp { get; } = null;
        public bool Active { get; }
    }
}
