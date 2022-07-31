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

            bool existing = await _context.Manufacturer.AnyAsync(x => x.Name == createManufacturer.Name);

            if (existing) return Conflict();

            Manufacturer manufacturer = new(createManufacturer);

            _context.Manufacturer.Add(manufacturer);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> Manufacturers = new();

            IAsyncEnumerable<Manufacturer> query = _context.Manufacturer
                .AsAsyncEnumerable();

            await foreach (Manufacturer manufacturer in query)
            {
                Manufacturers.Add(new DTO.Details(manufacturer));
            }

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

            if (manufacturer.Name != manufacturerEdits.Name)
            {
                bool conflictingName = await _context.Manufacturer.AnyAsync(x => x.Name == manufacturerEdits.Name);

                if (conflictingName) return Conflict();
            }

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
