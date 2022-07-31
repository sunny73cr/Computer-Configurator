using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.Radiator
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class RadiatorController : ControllerBase
    {
        private readonly CCContext _context;

        public RadiatorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createRadiator)
        {
            var errors = createRadiator.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createRadiator.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createRadiator)) return Conflict();

            bool RadiatorSizeExists = await _context.RadiatorSize.AnyAsync(x => x.UUID == createRadiator.RadiatorSizeUUID);

            if (RadiatorSizeExists == false) return NotFound();

            Radiator Radiator = new(createRadiator);

            _context.Radiator.Add(Radiator);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> Radiators = new();

            IAsyncEnumerable<Radiator> query = _context.Radiator
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.RadiatorSize)
                .AsAsyncEnumerable();

            await foreach (Radiator Radiator in query)
            {
                Radiators.Add(new DTO.Details(Radiator));
            }

            return Ok(Radiators);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            Radiator? Radiator = await _context.Radiator
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.RadiatorSize)
                .FirstOrDefaultAsync(Radiator => Radiator.UUID == uuid);

            if (Radiator == null) return NotFound();

            var details = new DTO.Details(Radiator);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit RadiatorEdits)
        {
            IReadOnlyList<string> errors = RadiatorEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            Radiator? Radiator = await _context.Radiator.FirstOrDefaultAsync(x => x.UUID == RadiatorEdits.UUID);

            if (Radiator == null) return NotFound();

            if (Radiator.ManufacturerUUID != RadiatorEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == RadiatorEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (Radiator.Model.ToLower() != RadiatorEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, RadiatorEdits);

                    if (duplicate) return Conflict();
                }
            }

            if (Radiator.RadiatorSizeUUID != RadiatorEdits.RadiatorSizeUUID)
            {
                bool RadiatorSizeExists = await _context.RadiatorSize.AnyAsync(x => x.UUID == RadiatorEdits.RadiatorSizeUUID);

                if (RadiatorSizeExists == false) return NotFound();
            }

            Radiator.Edit(Radiator, RadiatorEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            Radiator? Radiator = await _context.Radiator.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (Radiator == null) return NotFound();

            _context.Radiator.Remove(Radiator);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
