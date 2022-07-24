using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.ChassisZone
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class ChassisZoneController : ControllerBase
    {
        private readonly CCContext _context;

        public ChassisZoneController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createChassisZone)
        {
            var errors = createChassisZone.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisZone? existing = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == createChassisZone.UUID);

            if (existing != null) return Conflict();

            ChassisZone ChassisZone = new(createChassisZone);

            _context.ChassisZone.Add(ChassisZone);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> ChassisZones = await _context.ChassisZone
                .Select(chassisZone => new DTO.Details(chassisZone))
                .ToListAsync();

            return Ok(ChassisZones);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            ChassisZone? ChassisZone = await _context.ChassisZone.FirstOrDefaultAsync(ChassisZone => ChassisZone.UUID == uuid);

            if (ChassisZone == null) return NotFound();

            var details = new DTO.Details(ChassisZone);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit ChassisZoneEdits)
        {
            IReadOnlyList<string> errors = ChassisZoneEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisZone? ChassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == ChassisZoneEdits.UUID);

            if (ChassisZone == null) return NotFound();

            ChassisZone.Edit(ChassisZone, ChassisZoneEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            ChassisZone? ChassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (ChassisZone == null) return NotFound();

            _context.ChassisZone.Remove(ChassisZone);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
