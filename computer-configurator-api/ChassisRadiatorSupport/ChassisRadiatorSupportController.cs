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

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisRadiatorSupport)
        {
            IReadOnlyList<string> errors = createChassisRadiatorSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool existing = await _context.ChassisRadiatorSupport.AnyAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.RadiatorSizeUUID == createChassisRadiatorSupport.RadiatorSizeUUID
                && x.ChassisZoneUUID == createChassisRadiatorSupport.ChassisZoneUUID
            );

            if (existing) return Conflict();

            bool chassisExists = await _context.Chassis.AnyAsync(x => x.UUID == chassisUUID);

            if (chassisExists == false) return NotFound();

            bool radiatorSizeExists = await _context.RadiatorSize.AnyAsync(x => x.UUID == createChassisRadiatorSupport.RadiatorSizeUUID);

            if (radiatorSizeExists == false) return NotFound();

            bool chassisZoneExists = await _context.ChassisZone.AnyAsync(x => x.UUID == createChassisRadiatorSupport.ChassisZoneUUID);

            if (chassisZoneExists == false) return NotFound();

            ChassisRadiatorSupport ChassisRadiatorSupport = new(chassisUUID, createChassisRadiatorSupport);

            _context.ChassisRadiatorSupport.Add(ChassisRadiatorSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisRadiatorSupport = new();

            IAsyncEnumerable<ChassisRadiatorSupport> query = _context.ChassisRadiatorSupport
                .Include(x => x.RadiatorSize)
                .Include(x => x.ChassisZone)
                .Where(x => x.ChassisUUID == chassisUUID)
                .AsAsyncEnumerable();

            await foreach (ChassisRadiatorSupport chassisRadiatorSupport in query)
            {
                ChassisRadiatorSupport.Add(new DTO.Details(chassisRadiatorSupport));
            }

            return Ok(ChassisRadiatorSupport);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid chassisUUID, DTO.Edit editChassisRadiatorSupport)
        {
            IReadOnlyList<string> errors = editChassisRadiatorSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisRadiatorSupport? chassisRadiatorSupport = await _context.ChassisRadiatorSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.RadiatorSizeUUID == editChassisRadiatorSupport.RadiatorSizeUUID
                && x.ChassisZoneUUID == editChassisRadiatorSupport.ChassisZoneUUID
            );

            if (chassisRadiatorSupport == null) return NotFound();

            ChassisRadiatorSupport.Edit(chassisRadiatorSupport, editChassisRadiatorSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid radiatorSizeUUID, Guid chassisZoneUUID)
        {
            ChassisRadiatorSupport? chassisRadiatorSupport = await _context.ChassisRadiatorSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.RadiatorSizeUUID == radiatorSizeUUID
                && x.ChassisZoneUUID == chassisZoneUUID
            );

            if (chassisRadiatorSupport == null) return NotFound();

            _context.ChassisRadiatorSupport.Remove(chassisRadiatorSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
