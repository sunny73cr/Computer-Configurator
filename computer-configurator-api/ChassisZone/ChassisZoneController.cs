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

            bool existing = await _context.ChassisZone.AnyAsync(x => x.Zone == createChassisZone.Zone);

            if (existing) return Conflict();

            ChassisZone ChassisZone = new(createChassisZone);

            _context.ChassisZone.Add(ChassisZone);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> ChassisZones = new();

            IAsyncEnumerable<ChassisZone> query = _context.ChassisZone
                .AsAsyncEnumerable();

            await foreach (ChassisZone chassisZone in query)
            {
                ChassisZones.Add(new DTO.Details(chassisZone));
            }

            return Ok(ChassisZones);
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
