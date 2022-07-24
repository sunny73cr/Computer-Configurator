using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardChipset
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
    public class MotherboardChipsetController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardChipsetController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createMotherboardChipset)
        {
            var errors = createMotherboardChipset.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardChipset? existing = await _context.MotherboardChipset.FirstOrDefaultAsync(x => x.UUID == createMotherboardChipset.UUID);

            if (existing != null) return Conflict();

            Manufacturer.Manufacturer? manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(x => x.UUID == createMotherboardChipset.ManufacturerUUID);

            if (manufacturer == null) return NotFound("Manufacturer not found.");

            CPUSocket.CPUSocket? cpuSocket = await _context.CPUSocket.FirstOrDefaultAsync(x => x.UUID == createMotherboardChipset.CPUSocketUUID);

            if (cpuSocket == null) return NotFound("CPU Socket not found.");

            MotherboardChipset MotherboardChipset = new(createMotherboardChipset);

            _context.MotherboardChipset.Add(MotherboardChipset);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> MotherboardChipsets = await _context.MotherboardChipset
                .Include(x => x.Manufacturer)
                .Include(x => x.CPUSocket)
                .Select(motherboardChipset => new DTO.Details(motherboardChipset))
                .ToListAsync();

            return Ok(MotherboardChipsets);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            MotherboardChipset? MotherboardChipset = await _context.MotherboardChipset
                .Include(x => x.Manufacturer)
                .Include(x => x.CPUSocket)
                .FirstOrDefaultAsync(MotherboardChipset => MotherboardChipset.UUID == uuid);

            if (MotherboardChipset == null) return NotFound();

            var details = new DTO.Details(MotherboardChipset);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit MotherboardChipsetEdits)
        {
            IReadOnlyList<string> errors = MotherboardChipsetEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardChipset? MotherboardChipset = await _context.MotherboardChipset.FirstOrDefaultAsync(x => x.UUID == MotherboardChipsetEdits.UUID);

            if (MotherboardChipset == null) return NotFound();

            MotherboardChipset.Edit(MotherboardChipset, MotherboardChipsetEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            MotherboardChipset? MotherboardChipset = await _context.MotherboardChipset.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (MotherboardChipset == null) return NotFound();

            _context.MotherboardChipset.Remove(MotherboardChipset);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
