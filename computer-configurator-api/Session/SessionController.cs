using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ComputerConfigurator.Api.Session
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class SessionController : ControllerBase
    {
        private readonly CCContext _context;

        public SessionController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] DTO.Login authenticationDetails)
        {
            string? sessionKeyString = Request.Cookies[SessionCookie.Key];

            if (sessionKeyString != null)
            {
                bool validSessionKey = Guid.TryParse(sessionKeyString, out Guid sessionKey);

                if (validSessionKey)
                {
                    Session? existingSession = await _context.Session.FirstOrDefaultAsync(x => x.Key == sessionKey);

                    if (existingSession != null)
                    {
                        bool loggedIn = existingSession.LogoutTimestamp != null;

                        bool expired = existingSession.LoginTimestamp.AddSeconds(SessionCookie.SessionLifetime.TotalSeconds) <= DateTime.UtcNow;

                        if (loggedIn && expired == false) return NoContent();
                    }
                }
            }

            Account.Account? account = await _context.Account.FirstOrDefaultAsync(x => x.Email == authenticationDetails.Email);

            if (account == null) return Unauthorized();

            byte[] knownPassword = Convert.FromBase64String(account.Password);

            byte[] oldPasswordBytes = Encoding.Unicode.GetBytes(authenticationDetails.Password);

            byte[] oldSaltBytes = Convert.FromBase64String(account.Salt);

            byte[] testPassword = Authentication.Hash(oldPasswordBytes, oldSaltBytes);

            bool authenticated = Authentication.Verify(knownPassword, testPassword);

            if (!authenticated) return Unauthorized();

            Session session = new(account.UUID);

            _context.Session.Add(session);

            await _context.SaveChangesAsync();

            Response.Headers.SetCookie = SessionCookie.LoginCookie(session.Key);

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult> Logout()
        {
            string? sessionKey = Request.Cookies[SessionCookie.Key];

            if (sessionKey == null)
            {

                Response.Headers.SetCookie = SessionCookie.LogoutCookie();
                return NoContent();
            }

            bool validSessionKey = Guid.TryParse(sessionKey, out Guid sessionKeyGuid);

            if (!validSessionKey)
            {

                Response.Headers.SetCookie = SessionCookie.LogoutCookie();
                return NoContent();
            }

            Session? session = await _context.Session.FirstOrDefaultAsync(x => x.Key == sessionKeyGuid);

            if (session == null)
            {
                //log invalid session key

                Response.Headers.SetCookie = SessionCookie.LogoutCookie();
                return NoContent();
            }

            session.LogoutTimestamp = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            Response.Headers.SetCookie = SessionCookie.LogoutCookie();
            return NoContent();
        }
    }
}
