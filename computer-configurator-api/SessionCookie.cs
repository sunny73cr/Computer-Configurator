namespace ComputerConfigurator.Api
{
    public class SessionCookie
    {
        private static readonly TimeSpan SessionLifetime = new(
            days: 7,
            hours: 0,
            minutes: 0,
            seconds: 0,
            milliseconds: 0
        );

        public const string Key = "ccfgSession";
        public Guid SessionKey = Guid.Empty;
        public TimeSpan MaxAge = TimeSpan.Zero;
        public string Domain = string.Empty;
        public string Path = string.Empty;
        public SameSiteMode SameSiteMode = SameSiteMode.None;
        public bool? Secure = null;
        public bool? HttpOnly = null;

        public bool Valid = false;

        public SessionCookie(string cookieHeaderValue)
        {
            Dictionary<string, string> cookieKeyValues = new Dictionary<string, string>();  
            string[] parts = cookieHeaderValue.Split(';');
            foreach (string part in parts)
            {
                string[] keyValue = part.Split('=');
                string key = keyValue[0];
                string value = keyValue[1];
                cookieKeyValues.Add(key, value);
            }

            bool validGuid = Guid.TryParse(cookieKeyValues[SessionCookie.Key], out Guid cookieSessionKey);
            SessionKey = validGuid ? cookieSessionKey : Guid.Empty;

            bool validMaxAge = int.TryParse(cookieKeyValues["Max-Age"], out int maxAge);
            MaxAge = validMaxAge ? TimeSpan.FromSeconds(maxAge) : TimeSpan.Zero;

            bool validDomain = cookieKeyValues["Domain"] == "computecfg.com";
            Domain = validDomain ? cookieKeyValues["Domain"] : string.Empty;

            bool validPath = cookieKeyValues["Path"] == "/";
            Path = validPath ? cookieKeyValues["Path"] : string.Empty;

            switch (cookieKeyValues["SameSite"])
            {
                case "Strict":
                    SameSiteMode = SameSiteMode.Strict;
                    break;
                case "Lax":
                    SameSiteMode = SameSiteMode.Lax;
                    break;
                case "None":
                    SameSiteMode = SameSiteMode.None;
                    break;
                default:
                    SameSiteMode = SameSiteMode.Unspecified;
                    break;
            }
            bool validSameSiteMode = SameSiteMode == SameSiteMode.Strict;

            Secure = cookieHeaderValue.Contains("Secure");
            bool validSecurity = Secure == true;

            HttpOnly = cookieHeaderValue.Contains("HttpOnly");
            bool validAccessControl = HttpOnly == true;

            if (
                validGuid &&
                validMaxAge &&
                validDomain &&
                validPath &&
                validSameSiteMode &&
                validSecurity &&
                validAccessControl
            ) Valid = true;
        }

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
