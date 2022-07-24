using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.PowerSupplyFormFactor
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class PowerSupplyFormFactorController : ControllerBase
    {
        private readonly CCContext _context;

        public PowerSupplyFormFactorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createPowerSupplyFormFactor)
        {
            var errors = createPowerSupplyFormFactor.Validate();

            if (errors.Any()) return BadRequest(errors);

            PowerSupplyFormFactor? existing = await _context.PowerSupplyFormFactor.FirstOrDefaultAsync(x => x.UUID == createPowerSupplyFormFactor.UUID);

            if (existing != null) return Conflict();

            PowerSupplyFormFactor PowerSupplyFormFactor = new(createPowerSupplyFormFactor);

            _context.PowerSupplyFormFactor.Add(PowerSupplyFormFactor);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> PowerSupplyFormFactors = await _context.PowerSupplyFormFactor
                .Select(powerSupplyFormFactor => new DTO.Details(powerSupplyFormFactor))
                .ToListAsync();

            return Ok(PowerSupplyFormFactors);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            PowerSupplyFormFactor? PowerSupplyFormFactor = await _context.PowerSupplyFormFactor.FirstOrDefaultAsync(PowerSupplyFormFactor => PowerSupplyFormFactor.UUID == uuid);

            if (PowerSupplyFormFactor == null) return NotFound();

            var details = new DTO.Details(PowerSupplyFormFactor);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit PowerSupplyFormFactorEdits)
        {
            IReadOnlyList<string> errors = PowerSupplyFormFactorEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            PowerSupplyFormFactor? PowerSupplyFormFactor = await _context.PowerSupplyFormFactor.FirstOrDefaultAsync(x => x.UUID == PowerSupplyFormFactorEdits.UUID);

            if (PowerSupplyFormFactor == null) return NotFound();

            PowerSupplyFormFactor.Edit(PowerSupplyFormFactor, PowerSupplyFormFactorEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            PowerSupplyFormFactor? PowerSupplyFormFactor = await _context.PowerSupplyFormFactor.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (PowerSupplyFormFactor == null) return NotFound();

            _context.PowerSupplyFormFactor.Remove(PowerSupplyFormFactor);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
