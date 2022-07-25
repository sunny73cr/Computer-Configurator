using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.ChassisFanSupport
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class ChassisFanSupportController : ControllerBase
    {
        private readonly CCContext _context;

        public ChassisFanSupportController(CCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisFanSupports = await _context.ChassisFanSupport
                .Include(x => x.FanDiameter)
                .Include(x => x.ChassisZone)
                .Where(x => x.ChassisUUID == chassisUUID)
                .Select(ChassisFanSupport => new DTO.Details(ChassisFanSupport))
                .ToListAsync();

            return Ok(ChassisFanSupports);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisFanSupport)
        {
            IReadOnlyList<string> errors = createChassisFanSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisFanSupport? existing = await _context.ChassisFanSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.FanDiameterUUID == createChassisFanSupport.FanDiameterUUID
                && x.ChassisZoneUUID == createChassisFanSupport.ChassisZoneUUID
            );

            if (existing != null) return Conflict();

            Chassis.Chassis? chassis = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == chassisUUID);

            if (chassis == null) return NotFound();

            ChassisZone.ChassisZone? chassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == createChassisFanSupport.ChassisZoneUUID);

            if (chassisZone == null) return NotFound();

            FanDiameter.FanDiameter? fanDiameter = await _context.FanDiameter.FirstOrDefaultAsync(x => x.UUID == createChassisFanSupport.FanDiameterUUID);

            if (fanDiameter == null) return NotFound();

            ChassisFanSupport ChassisFanSupport = new(chassisUUID, createChassisFanSupport);

            _context.ChassisFanSupport.Add(ChassisFanSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid fanDiameterUUID, Guid chassisZoneUUID)
        {
            ChassisFanSupport? existing = await _context.ChassisFanSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.FanDiameterUUID == fanDiameterUUID
                && x.ChassisZoneUUID == chassisZoneUUID
            );

            if (existing == null) return NotFound();

            _context.ChassisFanSupport.Remove(existing);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
