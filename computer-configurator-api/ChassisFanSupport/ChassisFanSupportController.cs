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

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisFanSupport)
        {
            IReadOnlyList<string> errors = createChassisFanSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool existing = await _context.ChassisFanSupport.AnyAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.FanDiameterUUID == createChassisFanSupport.FanDiameterUUID
                && x.ChassisZoneUUID == createChassisFanSupport.ChassisZoneUUID
            );

            if (existing) return Conflict();

            bool chassisExists = await _context.Chassis.AnyAsync(x => x.UUID == chassisUUID);

            if (chassisExists == false) return NotFound();

            bool chassisZoneExists = await _context.ChassisZone.AnyAsync(x => x.UUID == createChassisFanSupport.ChassisZoneUUID);

            if (chassisZoneExists == false) return NotFound();

            bool fanDiameterExists = await _context.FanDiameter.AnyAsync(x => x.UUID == createChassisFanSupport.FanDiameterUUID);
            
            if (fanDiameterExists == false) return NotFound();

            ChassisFanSupport ChassisFanSupport = new(chassisUUID, createChassisFanSupport);

            _context.ChassisFanSupport.Add(ChassisFanSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisFanSupport = new();

            IAsyncEnumerable<ChassisFanSupport> query = _context.ChassisFanSupport
                .Include(x => x.FanDiameter)
                .Include(x => x.ChassisZone)
                .Where(x => x.ChassisUUID == chassisUUID)
                .AsAsyncEnumerable();

            await foreach (ChassisFanSupport chassisFanSupport in query)
            {
                ChassisFanSupport.Add(new DTO.Details(chassisFanSupport));
            }

            return Ok(ChassisFanSupport);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid chassisUUID, DTO.Edit editChassisFanSupport)
        {
            var errors = editChassisFanSupport.Validate();

            if (errors.Any()) return BadRequest(errors);
            
            ChassisFanSupport? chassisFanSupport = await _context.ChassisFanSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.FanDiameterUUID == editChassisFanSupport.FanDiameterUUID
                && x.ChassisZoneUUID == editChassisFanSupport.ChassisZoneUUID
            );

            if (chassisFanSupport == null) return NotFound();

            ChassisFanSupport.Edit(chassisFanSupport, editChassisFanSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid fanDiameterUUID, Guid chassisZoneUUID)
        {
            ChassisFanSupport? chassisFanSupport = await _context.ChassisFanSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.FanDiameterUUID == fanDiameterUUID
                && x.ChassisZoneUUID == chassisZoneUUID
            );

            if (chassisFanSupport == null) return NotFound();

            _context.ChassisFanSupport.Remove(chassisFanSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
