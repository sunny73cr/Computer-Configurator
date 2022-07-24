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

            RAIDMode? existing = await _context.RAIDMode.FirstOrDefaultAsync(x => x.UUID == createRAIDMode.UUID);

            if (existing != null) return Conflict();

            RAIDMode RAIDMode = new(createRAIDMode);

            _context.RAIDMode.Add(RAIDMode);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> RAIDModes = await _context.RAIDMode
                .Select(raidMode => new DTO.Details(raidMode))
                .ToListAsync();

            return Ok(RAIDModes);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            RAIDMode? RAIDMode = await _context.RAIDMode.FirstOrDefaultAsync(RAIDMode => RAIDMode.UUID == uuid);

            if (RAIDMode == null) return NotFound();

            var details = new DTO.Details(RAIDMode);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit RAIDModeEdits)
        {
            IReadOnlyList<string> errors = RAIDModeEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            RAIDMode? RAIDMode = await _context.RAIDMode.FirstOrDefaultAsync(x => x.UUID == RAIDModeEdits.UUID);

            if (RAIDMode == null) return NotFound();

            RAIDMode.Edit(RAIDMode, RAIDModeEdits);

            await _context.SaveChangesAsync();

            return NoContent();
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
