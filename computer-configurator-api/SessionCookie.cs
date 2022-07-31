namespace ComputerConfigurator.Api
{
    public class SessionCookie
    {
        public static readonly TimeSpan SessionLifetime = new(
            days: 7,
            hours: 0,
            minutes: 0,
            seconds: 0,
            milliseconds: 0
        );

        public const string Key = "ccfgSession";

        public static string LoginCookie(Guid sessionKey)
        {
            return
                //32 digits, no hypens, no braces
                $"{Key}={sessionKey.ToString("N")};" +
                $"Max-Age={SessionLifetime.TotalSeconds};" +
                $"Domain=localhost;" +
                $"Path=/;" +
                //$"SameSite=Strict;" +
                $"SameSite=None;" +
                //$"Secure;" +
                $"HttpOnly;";
        }

        public static string LogoutCookie()
        {
            return
                $"{Key}=LoggedOut;" +
                $"Max-Age=1;" +
                $"Domain=localhost;" +
                $"Path=/;" +
                //$"SameSite=Strict;" +
                $"SameSite=None;" +
                //$"Secure;" +
                $"HttpOnly;";
        }
    }
}
