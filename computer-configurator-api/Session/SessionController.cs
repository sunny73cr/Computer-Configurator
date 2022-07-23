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
            string? cookieString = Request.Cookies[SessionCookie.Key];

            if (cookieString != null && new SessionCookie(cookieString).Valid == true) return NoContent();

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
            string? cookieString = Request.Cookies[SessionCookie.Key];

            if (cookieString == null) return Unauthorized();

            SessionCookie cookie = new(cookieString);

            if (cookie.Valid == false) return Unauthorized();

            //log invalid cookie

            Session? session = await _context.Session.FirstOrDefaultAsync(x => x.Key == cookie.SessionKey);

            if (session == null) return Unauthorized();

            session.LogoutTimestamp = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            Response.Headers.SetCookie = SessionCookie.LogoutCookie();

            return NoContent();
        }
    }
}
