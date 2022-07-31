using Microsoft.EntityFrameworkCore;

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

        public static async Task<Session?> ValdiateExistingSession(CCContext context, IRequestCookieCollection cookies)
        {
            string? sessionKeyString = cookies[SessionCookie.Key];

            if (sessionKeyString == null) return null;

            bool validSessionKey = Guid.TryParse(sessionKeyString, out Guid sessionKey);

            if (validSessionKey == false) return null;

            Session? existingSession = await context.Session.FirstOrDefaultAsync(x => x.Key == sessionKey);

            if (existingSession == null) return null;

            bool loggedIn = existingSession.LogoutTimestamp != null;

            if (loggedIn == false) return null;

            bool expired = existingSession.LoginTimestamp.AddSeconds(SessionCookie.SessionLifetime.TotalSeconds) <= DateTime.UtcNow;

            if (expired) return null;

            return existingSession;
        }
    }
}
