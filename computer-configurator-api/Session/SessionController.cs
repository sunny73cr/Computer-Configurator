using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult> WhoAmI()
        {
            Session? mySession = await Session.ValdiateExistingSession(_context, Request.Cookies);

            if (mySession == null) return Unauthorized();

            Account.DTO.Details accountDetails = new(mySession.Account);

            return Ok(accountDetails);
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] DTO.Login authenticationDetails)
        {
            Session? existingSession = await Session.ValdiateExistingSession(_context, Request.Cookies);

            if (existingSession != null) return NoContent();

            Account.Account? account = await _context.Account.FirstOrDefaultAsync(x => x.Email == authenticationDetails.Email);

            if (account == null) return Unauthorized();

            if (account.VerifyPassword(authenticationDetails.Password) == false) return Unauthorized();

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

            if (validSessionKey == false)
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
