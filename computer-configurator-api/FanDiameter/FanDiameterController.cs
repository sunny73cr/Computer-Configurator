using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.FanDiameter
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class FanDiameterController : ControllerBase
    {
        private readonly CCContext _context;

        public FanDiameterController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createFanDiameter)
        {
            var errors = createFanDiameter.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool duplicate = await _context.FanDiameter.AnyAsync(x => x.Diameter == createFanDiameter.Diameter);

            if (duplicate) return Conflict();

            FanDiameter FanDiameter = new(createFanDiameter);

            _context.FanDiameter.Add(FanDiameter);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> FanDiameters = await _context.FanDiameter
                .Select(fanDiameter => new DTO.Details(fanDiameter))
                .ToListAsync();

            return Ok(FanDiameters);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            FanDiameter? FanDiameter = await _context.FanDiameter.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (FanDiameter == null) return NotFound();

            _context.FanDiameter.Remove(FanDiameter);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
