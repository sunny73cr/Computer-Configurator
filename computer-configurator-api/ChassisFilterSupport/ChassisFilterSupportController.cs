using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.ChassisFilterSupport
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class ChassisFilterSupportController : ControllerBase
    {
        private readonly CCContext _context;

        public ChassisFilterSupportController(CCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisFilterSupports = await _context.ChassisFilterSupport
                .Include(x => x.ChassisZone)
                .Where(x => x.ChassisUUID == chassisUUID)
                .Select(ChassisFilterSupport => new DTO.Details(ChassisFilterSupport))
                .ToListAsync();

            return Ok(ChassisFilterSupports);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisFilterSupport)
        {
            IReadOnlyList<string> errors = createChassisFilterSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisFilterSupport? existing = await _context.ChassisFilterSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.ChassisZoneUUID == createChassisFilterSupport.ChassisZoneUUID
            );

            if (existing != null) return Conflict();

            Chassis.Chassis? chassis = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == chassisUUID);

            if (chassis == null) return NotFound();

            ChassisZone.ChassisZone? chassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == createChassisFilterSupport.ChassisZoneUUID);

            if (chassisZone == null) return NotFound();

            ChassisFilterSupport ChassisFilterSupport = new(chassisUUID, createChassisFilterSupport);

            _context.ChassisFilterSupport.Add(ChassisFilterSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid chassisZoneUUID)
        {
            ChassisFilterSupport? existing = await _context.ChassisFilterSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.ChassisZoneUUID == chassisZoneUUID
            );

            if (existing == null) return NotFound();

            _context.ChassisFilterSupport.Remove(existing);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
