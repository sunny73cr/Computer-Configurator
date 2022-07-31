using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.PowerSupply
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class PowerSupplyController : ControllerBase
    {
        private readonly CCContext _context;

        public PowerSupplyController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createPowerSupply)
        {
            var errors = createPowerSupply.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createPowerSupply.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createPowerSupply)) return Conflict();

            bool PowerSupplyFormFactorExists = await _context.PowerSupplyFormFactor.AnyAsync(x => x.UUID == createPowerSupply.PowerSupplyFormFactorUUID);

            if (PowerSupplyFormFactorExists == false) return NotFound();

            bool EightyPlusRatingExists = await _context.EightyPlusRating.AnyAsync(x => x.UUID == createPowerSupply.EightyPlusRatingUUID);

            if (EightyPlusRatingExists == false) return NotFound();

            PowerSupply PowerSupply = new(createPowerSupply);

            _context.PowerSupply.Add(PowerSupply);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> PowerSupplys = new();

            IAsyncEnumerable<PowerSupply> query = _context.PowerSupply
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.PowerSupplyFormFactor)
                .Include(x => x.EightyPlusRating)
                .AsAsyncEnumerable();

            await foreach (PowerSupply PowerSupply in query)
            {
                PowerSupplys.Add(new DTO.Details(PowerSupply));
            }

            return Ok(PowerSupplys);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            PowerSupply? PowerSupply = await _context.PowerSupply
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.PowerSupplyFormFactor)
                .Include(x => x.EightyPlusRating)
                .FirstOrDefaultAsync(PowerSupply => PowerSupply.UUID == uuid);

            if (PowerSupply == null) return NotFound();

            var details = new DTO.Details(PowerSupply);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit PowerSupplyEdits)
        {
            IReadOnlyList<string> errors = PowerSupplyEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            PowerSupply? PowerSupply = await _context.PowerSupply.FirstOrDefaultAsync(x => x.UUID == PowerSupplyEdits.UUID);

            if (PowerSupply == null) return NotFound();

            if (PowerSupply.ManufacturerUUID != PowerSupplyEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == PowerSupplyEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (PowerSupply.Model.ToLower() != PowerSupplyEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, PowerSupplyEdits);

                    if (duplicate) return Conflict();
                }
            }

            if (PowerSupply.PowerSupplyFormFactorUUID != PowerSupplyEdits.PowerSupplyFormFactorUUID)
            {
                bool PowerSupplyFormFactorExists = await _context.PowerSupplyFormFactor.AnyAsync(x => x.UUID == PowerSupplyEdits.PowerSupplyFormFactorUUID);

                if (PowerSupplyFormFactorExists == false) return NotFound();
            }

            if (PowerSupply.EightyPlusRatingUUID != PowerSupplyEdits.EightyPlusRatingUUID)
            {
                bool EightyPlusRatingExists = await _context.EightyPlusRating.AnyAsync(x => x.UUID == PowerSupplyEdits.EightyPlusRatingUUID);

                if (EightyPlusRatingExists == false) return NotFound();
            }

            PowerSupply.Edit(PowerSupply, PowerSupplyEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            PowerSupply? PowerSupply = await _context.PowerSupply.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (PowerSupply == null) return NotFound();

            _context.PowerSupply.Remove(PowerSupply);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
