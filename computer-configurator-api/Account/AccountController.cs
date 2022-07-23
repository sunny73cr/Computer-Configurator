using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ComputerConfigurator.Api.Account
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class AccountController : ControllerBase
    {
        private readonly CCContext _context;

        public AccountController(CCContext context) : base()
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]DTO.Create newAccount)
        {
            var errors = newAccount.Validate();

            if (errors.Count > 0) return BadRequest(errors);

            Account? existingAccount = await _context.Account.FirstOrDefaultAsync(x => x.Email == newAccount.Email);

            if (existingAccount != null) return Conflict();

            byte[] saltBytes = Authentication.CreateSalt();

            byte[] passwordBytes = Encoding.Unicode.GetBytes(newAccount.Password);

            byte[] passwordHashBytes = Authentication.Hash(passwordBytes, saltBytes);

            string passwordHashBase64 = Convert.ToBase64String(passwordHashBytes);

            string saltBase64 = Convert.ToBase64String(saltBytes);

            Account account = new(newAccount, passwordHashBase64, saltBase64);

            _context.Account.Add(account);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByEmail(string Email)
        {
            Account? account = await _context.Account.FirstOrDefaultAsync(x => x.Email == Email);

            if (account == null) return NotFound();

            var details = new DTO.Details(account);

            return Ok(details);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            Account? account = await _context.Account.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (account == null) return NotFound();

            var details = new DTO.Details(account);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody]DTO.Edit edits)
        {
            var errors = edits.Validate();

            if (errors.Count > 0) return BadRequest(errors);

            Account? account = await _context.Account.FirstOrDefaultAsync(x => x.UUID == edits.UUID);

            if (account == null) return NotFound();

            Account.Edit(account, edits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult> ChangePassword([FromBody] DTO.ChangePassword changePassword)
        {
            var errors = changePassword.Validate();

            if (errors.Count > 0) return BadRequest(errors);

            //  AccountQueries.GetByUUID(changePassword.AccountUUID);

            Account? account = await _context.Account.FirstOrDefaultAsync(x => x.UUID == changePassword.AccountUUID);

            if (account == null) return NotFound();

            byte[] knownPasswordHash = Convert.FromBase64String(account.Password);

            byte[] oldPasswordBytes = Encoding.Unicode.GetBytes(changePassword.OldPassword);

            byte[] oldSaltBytes = Convert.FromBase64String(account.Salt);

            byte[] testPasswordHash = Authentication.Hash(oldPasswordBytes, oldSaltBytes);

            bool authenticated = Authentication.Verify(knownPasswordHash, testPasswordHash);

            if (!authenticated) return Unauthorized();

            byte[] newSaltBytes = Authentication.CreateSalt();

            byte[] newPasswordBytes = Encoding.Unicode.GetBytes(changePassword.NewPassword);

            byte[] newHash = Authentication.Hash(newPasswordBytes, newSaltBytes);

            string newPassword = Convert.ToBase64String(newHash);

            string newSalt = Convert.ToBase64String(newSaltBytes);

            account.Password = newPassword;

            account.Salt = newSalt;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            Account? account = await _context.Account.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (account == null) return NotFound();

            _context.Account.Remove(account);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
