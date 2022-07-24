using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.FanDiameter
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
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

            FanDiameter? existing = await _context.FanDiameter.FirstOrDefaultAsync(x => x.UUID == createFanDiameter.UUID);

            if (existing != null) return Conflict();

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

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            FanDiameter? FanDiameter = await _context.FanDiameter.FirstOrDefaultAsync(FanDiameter => FanDiameter.UUID == uuid);

            if (FanDiameter == null) return NotFound();

            var details = new DTO.Details(FanDiameter);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit FanDiameterEdits)
        {
            IReadOnlyList<string> errors = FanDiameterEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            FanDiameter? FanDiameter = await _context.FanDiameter.FirstOrDefaultAsync(x => x.UUID == FanDiameterEdits.UUID);

            if (FanDiameter == null) return NotFound();

            FanDiameter.Edit(FanDiameter, FanDiameterEdits);

            await _context.SaveChangesAsync();

            return NoContent();
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
