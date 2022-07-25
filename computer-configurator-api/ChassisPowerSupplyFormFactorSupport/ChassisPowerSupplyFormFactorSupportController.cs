using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.ChassisPowerSupplyFormFactorSupport
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class ChassisPowerSupplyFormFactorSupportController : ControllerBase
    {
        private readonly CCContext _context;

        public ChassisPowerSupplyFormFactorSupportController(CCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisPowerSupplyFormFactorSupports = await _context.ChassisPowerSupplyFormFactorSupport
                .Include(x => x.PowerSupplyFormFactor)
                .Where(x => x.ChassisUUID == chassisUUID)
                .Select(ChassisPowerSupplyFormFactorSupport => new DTO.Details(ChassisPowerSupplyFormFactorSupport))
                .ToListAsync();

            return Ok(ChassisPowerSupplyFormFactorSupports);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisPowerSupplyFormFactorSupport)
        {
            IReadOnlyList<string> errors = createChassisPowerSupplyFormFactorSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisPowerSupplyFormFactorSupport? existing = await _context.ChassisPowerSupplyFormFactorSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.PowerSupplyFormFactorUUID == createChassisPowerSupplyFormFactorSupport.PowerSupplyFormFactorUUID
            );

            if (existing != null) return Conflict();

            Chassis.Chassis? chassis = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == chassisUUID);

            if (chassis == null) return NotFound();

            PowerSupplyFormFactor.PowerSupplyFormFactor? chassisZone = await _context.PowerSupplyFormFactor.FirstOrDefaultAsync(x => x.UUID == createChassisPowerSupplyFormFactorSupport.PowerSupplyFormFactorUUID);

            if (chassisZone == null) return NotFound();

            ChassisPowerSupplyFormFactorSupport ChassisPowerSupplyFormFactorSupport = new(chassisUUID, createChassisPowerSupplyFormFactorSupport);

            _context.ChassisPowerSupplyFormFactorSupport.Add(ChassisPowerSupplyFormFactorSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid powerSupplyFormFactorUUID)
        {
            ChassisPowerSupplyFormFactorSupport? existing = await _context.ChassisPowerSupplyFormFactorSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.PowerSupplyFormFactorUUID == powerSupplyFormFactorUUID
            );

            if (existing == null) return NotFound();

            _context.ChassisPowerSupplyFormFactorSupport.Remove(existing);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
