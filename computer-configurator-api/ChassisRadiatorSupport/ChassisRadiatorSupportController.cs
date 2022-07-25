using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.ChassisRadiatorSupport
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class ChassisRadiatorSupportController : ControllerBase
    {
        private readonly CCContext _context;

        public ChassisRadiatorSupportController(CCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisRadiatorSupports = await _context.ChassisRadiatorSupport
                .Include(x => x.RadiatorSize)
                .Include(x => x.ChassisZone)
                .Where(x => x.ChassisUUID == chassisUUID)
                .Select(ChassisRadiatorSupport => new DTO.Details(ChassisRadiatorSupport))
                .ToListAsync();

            return Ok(ChassisRadiatorSupports);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisRadiatorSupport)
        {
            IReadOnlyList<string> errors = createChassisRadiatorSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisRadiatorSupport? existing = await _context.ChassisRadiatorSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.RadiatorSizeUUID == createChassisRadiatorSupport.RadiatorSizeUUID
                && x.ChassisZoneUUID == createChassisRadiatorSupport.ChassisZoneUUID
            );

            if (existing != null) return Conflict();

            Chassis.Chassis? chassis = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == chassisUUID);

            if (chassis == null) return NotFound();

            RadiatorSize.RadiatorSize? radiatorSize = await _context.RadiatorSize.FirstOrDefaultAsync(x => x.UUID == createChassisRadiatorSupport.RadiatorSizeUUID);

            if (radiatorSize == null) return NotFound();

            ChassisZone.ChassisZone? chassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == createChassisRadiatorSupport.ChassisZoneUUID);

            if (chassisZone == null) return NotFound();

            ChassisRadiatorSupport ChassisRadiatorSupport = new(chassisUUID, createChassisRadiatorSupport);

            _context.ChassisRadiatorSupport.Add(ChassisRadiatorSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid radiatorSizeUUID, Guid chassisZoneUUID)
        {
            ChassisRadiatorSupport? existing = await _context.ChassisRadiatorSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.RadiatorSizeUUID == radiatorSizeUUID
                && x.ChassisZoneUUID == chassisZoneUUID
            );

            if (existing == null) return NotFound();

            _context.ChassisRadiatorSupport.Remove(existing);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
