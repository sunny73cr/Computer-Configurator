using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.Chassis
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class ChassisController : ControllerBase
    {
        private readonly CCContext _context;

        public ChassisController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createChassis)
        {
            var errors = createChassis.Validate();

            if (errors.Any()) return BadRequest(errors);

            Chassis? existing = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == createChassis.UUID);

            if (existing != null) return Conflict();

            Chassis Chassis = new(createChassis);

            _context.Chassis.Add(Chassis);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            Chassis? Chassis = await _context.Chassis
                .Include(Chassis => Chassis.Part)
                .ThenInclude(part => part.Manufacturer)
                .FirstOrDefaultAsync(Chassis => Chassis.UUID == uuid);

            if (Chassis == null) return NotFound();

            var details = new DTO.Details(Chassis);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit ChassisEdits)
        {
            IReadOnlyList<string> errors = ChassisEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            Chassis? Chassis = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == ChassisEdits.UUID);

            if (Chassis == null) return NotFound();

            Chassis.Edit(Chassis, ChassisEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            Chassis? placeholder = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (placeholder == null) return NotFound();

            _context.Chassis.Remove(placeholder);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
