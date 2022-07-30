using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            bool existingAccount = await _context.Account.AnyAsync(x => x.Email == newAccount.Email.ToLower());

            if (existingAccount) return Conflict();

            Account account = new(newAccount);

            _context.Account.Add(account);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByEmail(string Email)
        {
            Account? account = await _context.Account.FirstOrDefaultAsync(x => x.Email == Email.ToLower());

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

            if (account.Email != edits.Email.ToLower())
            {
                bool existingAccount = await _context.Account.AnyAsync(x => x.Email == edits.Email.ToLower());

                if (existingAccount) return Conflict();
            }

            Account.Edit(account, edits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult> ChangePassword([FromBody] DTO.ChangePassword changePassword)
        {
            var errors = changePassword.Validate();

            if (errors.Count > 0) return BadRequest(errors);

            Account? account = await _context.Account.FirstOrDefaultAsync(x => x.UUID == changePassword.AccountUUID);

            if (account == null) return NotFound();

            if (account.VerifyPassword(changePassword.OldPassword) == false) return Unauthorized();

            account.SetNewPassword(changePassword.NewPassword);

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
