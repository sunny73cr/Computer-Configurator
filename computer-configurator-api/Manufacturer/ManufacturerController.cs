using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.Manufacturer
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class ManufacturerController : ControllerBase
    {
        private readonly CCContext _context;

        public ManufacturerController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createManufacturer)
        {
            var errors = createManufacturer.Valdiate();

            if (errors.Any()) return BadRequest(errors);

            Manufacturer? existing = await _context.Manufacturer.FirstOrDefaultAsync(x => x.Name == createManufacturer.Name);

            if (existing != null) return Conflict();

            Manufacturer manufacturer = new(createManufacturer);

            _context.Manufacturer.Add(manufacturer);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> Manufacturers = await _context.Manufacturer
                .Select(manufacturer => new DTO.Details(manufacturer))
                .ToListAsync();

            return Ok(Manufacturers);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByName(string name)
        {
            Manufacturer? manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(x => x.Name == name);

            if (manufacturer == null) return NotFound();

            var details = new DTO.Details(manufacturer);

            return Ok(details);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            Manufacturer? manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (manufacturer == null) return NotFound();

            var details = new DTO.Details(manufacturer);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit manufacturerEdits)
        {
            IReadOnlyList<string> errors = manufacturerEdits.Valdiate();

            if (errors.Any()) return BadRequest(errors);

            Manufacturer? manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(x => x.UUID == manufacturerEdits.UUID);

            if (manufacturer == null) return NotFound();

            Manufacturer.Edit(manufacturer, manufacturerEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            Manufacturer? manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (manufacturer == null) return NotFound();

            _context.Manufacturer.Remove(manufacturer);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
