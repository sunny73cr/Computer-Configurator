using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.RAMSpeed
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class RAMSpeedController : ControllerBase
    {
        private readonly CCContext _context;

        public RAMSpeedController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createRAMSpeed)
        {
            var errors = createRAMSpeed.Validate();

            if (errors.Any()) return BadRequest(errors);

            RAMSpeed? existing = await _context.RAMSpeed.FirstOrDefaultAsync(x => x.UUID == createRAMSpeed.UUID);

            if (existing != null) return Conflict();

            RAMSpeed RAMSpeed = new(createRAMSpeed);

            _context.RAMSpeed.Add(RAMSpeed);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> RAMSpeeds = await _context.RAMSpeed
                .Select(ramSpeeds => new DTO.Details(ramSpeeds))
                .ToListAsync();

            return Ok(RAMSpeeds);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            RAMSpeed? RAMSpeed = await _context.RAMSpeed.FirstOrDefaultAsync(RAMSpeed => RAMSpeed.UUID == uuid);

            if (RAMSpeed == null) return NotFound();

            var details = new DTO.Details(RAMSpeed);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit RAMSpeedEdits)
        {
            IReadOnlyList<string> errors = RAMSpeedEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            RAMSpeed? RAMSpeed = await _context.RAMSpeed.FirstOrDefaultAsync(x => x.UUID == RAMSpeedEdits.UUID);

            if (RAMSpeed == null) return NotFound();

            RAMSpeed.Edit(RAMSpeed, RAMSpeedEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            RAMSpeed? RAMSpeed = await _context.RAMSpeed.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (RAMSpeed == null) return NotFound();

            _context.RAMSpeed.Remove(RAMSpeed);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
