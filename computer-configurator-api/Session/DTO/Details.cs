namespace ComputerConfigurator.Api.Session.DTO
{
    public class Details
    {
        public const string SQLParameters = "key, accountuuid, logintimestamp, logouttimestamp";

        public Guid Key { get; set; }
        public Guid AccountUUID { get; set; }
        public DateTime LoginTimestamp { get; set; }
        public DateTime? LogoutTimestamp { get; set; }

        public Details()
        {

        }

        public Details(Session session)
        {
            Key = session.Key;
            AccountUUID = session.AccountUUID;
            LoginTimestamp = session.LoginTimestamp;
            LogoutTimestamp = session.LogoutTimestamp;
        }

        public Details(IDictionary<string, object> session)
        {
            Key = (Guid)session["key"];
            AccountUUID = (Guid)session["accountuuid"];
            LoginTimestamp = (DateTime)session["logintimestamp"];
            LogoutTimestamp = (DateTime)session["logouttimestamp"];
        }
    }
}
