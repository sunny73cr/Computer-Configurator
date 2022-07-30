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

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisFilterSupport)
        {
            IReadOnlyList<string> errors = createChassisFilterSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool existing = await _context.ChassisFilterSupport.AnyAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.ChassisZoneUUID == createChassisFilterSupport.ChassisZoneUUID
            );

            if (existing) return Conflict();

            bool chassisExists = await _context.Chassis.AnyAsync(x => x.UUID == chassisUUID);

            if (chassisExists == false) return NotFound();

            bool chassisZoneExists = await _context.ChassisZone.AnyAsync(x => x.UUID == createChassisFilterSupport.ChassisZoneUUID);

            if (chassisZoneExists == false) return NotFound();

            ChassisFilterSupport ChassisFilterSupport = new(chassisUUID, createChassisFilterSupport);

            _context.ChassisFilterSupport.Add(ChassisFilterSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisFilterSupport = new();

            IAsyncEnumerable<ChassisFilterSupport> query = _context.ChassisFilterSupport
                .Include(x => x.ChassisZone)
                .Where(x => x.ChassisUUID == chassisUUID)
                .AsAsyncEnumerable();

            await foreach (ChassisFilterSupport chassisFilterSupport in query)
            {
                ChassisFilterSupport.Add(new DTO.Details(chassisFilterSupport));
            }

            return Ok(ChassisFilterSupport);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid chassisUUID, DTO.Edit editChassisFilterSupport)
        {
            IReadOnlyList<string> errors = editChassisFilterSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisFilterSupport? chassisFilterSupport = await _context.ChassisFilterSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.ChassisZoneUUID == editChassisFilterSupport.ChassisZoneUUID
            );

            if (chassisFilterSupport == null) return NotFound();

            ChassisFilterSupport.Edit(chassisFilterSupport, editChassisFilterSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid chassisZoneUUID)
        {
            ChassisFilterSupport? chassisFilterSupport = await _context.ChassisFilterSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.ChassisZoneUUID == chassisZoneUUID
            );

            if (chassisFilterSupport == null) return NotFound();

            _context.ChassisFilterSupport.Remove(chassisFilterSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
