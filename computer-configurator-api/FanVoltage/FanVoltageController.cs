using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.FanVoltage
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class FanVoltageController : ControllerBase
    {
        private readonly CCContext _context;

        public FanVoltageController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createFanVoltage)
        {
            var errors = createFanVoltage.Validate();

            if (errors.Any()) return BadRequest(errors);

            FanVoltage? existing = await _context.FanVoltage.FirstOrDefaultAsync(x => x.UUID == createFanVoltage.UUID);

            if (existing != null) return Conflict();

            FanVoltage FanVoltage = new(createFanVoltage);

            _context.FanVoltage.Add(FanVoltage);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> FanVoltages = await _context.FanVoltage
                .Select(fanVoltage => new DTO.Details(fanVoltage))
                .ToListAsync();

            return Ok(FanVoltages);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            FanVoltage? FanVoltage = await _context.FanVoltage.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (FanVoltage == null) return NotFound();

            _context.FanVoltage.Remove(FanVoltage);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
