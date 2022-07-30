using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.RAIDMode
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class RAIDModeController : ControllerBase
    {
        private readonly CCContext _context;

        public RAIDModeController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createRAIDMode)
        {
            var errors = createRAIDMode.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool duplicate = await _context.RAIDMode.AnyAsync(x => x.Mode == createRAIDMode.Mode);

            if (duplicate) return Conflict();

            RAIDMode RAIDMode = new(createRAIDMode);

            _context.RAIDMode.Add(RAIDMode);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> RAIDModes = new();

            IAsyncEnumerable<RAIDMode> query = _context.RAIDMode
                .AsAsyncEnumerable();

            await foreach (RAIDMode raidMode in query)
            {
                RAIDModes.Add(new DTO.Details(raidMode));
            }

            return Ok(RAIDModes);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            RAIDMode? RAIDMode = await _context.RAIDMode.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (RAIDMode == null) return NotFound();

            _context.RAIDMode.Remove(RAIDMode);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
