using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.Fan
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class FanController : ControllerBase
    {
        private readonly CCContext _context;

        public FanController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createFan)
        {
            var errors = createFan.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createFan.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createFan)) return Conflict();

            bool fanDiameterExists = await _context.FanDiameter.AnyAsync(x => x.UUID == createFan.FanDiameterUUID);

            if (fanDiameterExists == false) return NotFound();

            bool fanVoltageExists = await _context.FanVoltage.AnyAsync(x => x.UUID == createFan.FanVoltageUUID);

            if (fanVoltageExists == false) return NotFound();

            Fan Fan = new(createFan);

            _context.Fan.Add(Fan);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            Fan? Fan = await _context.Fan
                .Include(Fan => Fan.FanDiameter)
                .Include(Fan => Fan.FanVoltage)
                .Include(Fan => Fan.Part)
                .ThenInclude(part => part.Manufacturer)
                .FirstOrDefaultAsync(Fan => Fan.UUID == uuid);

            if (Fan == null) return NotFound();

            var details = new DTO.Details(Fan);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit FanEdits)
        {
            IReadOnlyList<string> errors = FanEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            Fan? Fan = await _context.Fan.FirstOrDefaultAsync(x => x.UUID == FanEdits.UUID);

            if (Fan == null) return NotFound();

            if (Fan.ManufacturerUUID != FanEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == FanEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (Fan.Model.ToLower() != FanEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, FanEdits);

                    if (duplicate) return Conflict();
                }
            }

            bool fanDiameterExists = await _context.FanDiameter.AnyAsync(x => x.UUID == FanEdits.FanDiameterUUID);

            if (fanDiameterExists == false) return NotFound();

            bool fanVoltageExists = await _context.FanVoltage.AnyAsync(x => x.UUID == FanEdits.FanVoltageUUID);

            if (fanVoltageExists == false) return NotFound();

            Fan.Edit(Fan, FanEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            Fan? placeholder = await _context.Fan.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (placeholder == null) return NotFound();

            _context.Fan.Remove(placeholder);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

