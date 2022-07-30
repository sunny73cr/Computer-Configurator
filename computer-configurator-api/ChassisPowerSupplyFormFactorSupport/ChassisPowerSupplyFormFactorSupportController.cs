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

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisPowerSupplyFormFactorSupport)
        {
            IReadOnlyList<string> errors = createChassisPowerSupplyFormFactorSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool existing = await _context.ChassisPowerSupplyFormFactorSupport.AnyAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.PowerSupplyFormFactorUUID == createChassisPowerSupplyFormFactorSupport.PowerSupplyFormFactorUUID
            );

            if (existing) return Conflict();

            bool chassisExists = await _context.Chassis.AnyAsync(x => x.UUID == chassisUUID);

            if (chassisExists == false) return NotFound();

            bool chassisZoneExists = await _context.PowerSupplyFormFactor.AnyAsync(x => x.UUID == createChassisPowerSupplyFormFactorSupport.PowerSupplyFormFactorUUID);

            if (chassisZoneExists == false) return NotFound();

            ChassisPowerSupplyFormFactorSupport ChassisPowerSupplyFormFactorSupport = new(chassisUUID, createChassisPowerSupplyFormFactorSupport);

            _context.ChassisPowerSupplyFormFactorSupport.Add(ChassisPowerSupplyFormFactorSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisPowerSupplyFormFactorSupport = new();

            IAsyncEnumerable<ChassisPowerSupplyFormFactorSupport> query = _context.ChassisPowerSupplyFormFactorSupport
                .Include(x => x.PowerSupplyFormFactor)
                .Where(x => x.ChassisUUID == chassisUUID)
                .AsAsyncEnumerable();

            await foreach (ChassisPowerSupplyFormFactorSupport chassisPowerSupplyFormFactorSupport in query)
            {
                ChassisPowerSupplyFormFactorSupport.Add(new DTO.Details(chassisPowerSupplyFormFactorSupport));
            }

            return Ok(ChassisPowerSupplyFormFactorSupport);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid chassisUUID, DTO.Edit editChassisPowerSupplyFormFactorSupport)
        {
            IReadOnlyList<string> errors = editChassisPowerSupplyFormFactorSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisPowerSupplyFormFactorSupport? chassisPowerSupplyFormFactorSupport = await _context.ChassisPowerSupplyFormFactorSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.PowerSupplyFormFactorUUID == editChassisPowerSupplyFormFactorSupport.PowerSupplyFormFactorUUID
            );

            if (chassisPowerSupplyFormFactorSupport == null) return NotFound();

            ChassisPowerSupplyFormFactorSupport.Edit(chassisPowerSupplyFormFactorSupport, editChassisPowerSupplyFormFactorSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid powerSupplyFormFactorUUID)
        {
            ChassisPowerSupplyFormFactorSupport? chassisPowerSupplyFormFactorSupport = await _context.ChassisPowerSupplyFormFactorSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.PowerSupplyFormFactorUUID == powerSupplyFormFactorUUID
            );

            if (chassisPowerSupplyFormFactorSupport == null) return NotFound();

            _context.ChassisPowerSupplyFormFactorSupport.Remove(chassisPowerSupplyFormFactorSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
