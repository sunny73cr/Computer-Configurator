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

            bool duplicate = await _context.PowerSupplyFormFactor.AnyAsync(x => x.FormFactor == createPowerSupplyFormFactor.FormFactor);

            if (duplicate) return Conflict();

            PowerSupplyFormFactor PowerSupplyFormFactor = new(createPowerSupplyFormFactor);

            _context.PowerSupplyFormFactor.Add(PowerSupplyFormFactor);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> PowerSupplyFormFactors = new();

            IAsyncEnumerable<PowerSupplyFormFactor> query = _context.PowerSupplyFormFactor
                .AsAsyncEnumerable();

            await foreach (PowerSupplyFormFactor powerSupplyFormFactor in query)
            {
                PowerSupplyFormFactors.Add(new DTO.Details(powerSupplyFormFactor));
            }

            return Ok(PowerSupplyFormFactors);
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
