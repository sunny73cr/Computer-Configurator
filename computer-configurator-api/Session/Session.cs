namespace ComputerConfigurator.Api.Session
{
    public partial class Session
    {
        public Guid Key { get; set; } = Guid.Empty;
        public Guid AccountUUID { get; set; } = Guid.Empty;
        public DateTime LoginTimestamp { get; set; }
        public DateTime? LogoutTimestamp { get; set; } = null;

        public virtual Account.Account Account { get; set; } = null!;

        public Session()
        {

        }

        public Session(Guid accountUUID)
        {
            Key = Guid.NewGuid();
            AccountUUID = accountUUID;
            LoginTimestamp = DateTime.UtcNow;
            LogoutTimestamp = null;
        }
    }
}
