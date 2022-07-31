using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardChipset
{
    [ApiController]
    [Route("/[controller]/[action]/")]
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

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createMotherboardChipset.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound("Manufacturer not found.");

            bool cpuSocketExists = await _context.CPUSocket.AnyAsync(x => x.UUID == createMotherboardChipset.CPUSocketUUID);

            if (cpuSocketExists == false) return NotFound("CPU Socket not found.");

            bool duplicate = await _context.MotherboardChipset.AnyAsync(x =>
                x.ManufacturerUUID == createMotherboardChipset.ManufacturerUUID
                && x.Version == createMotherboardChipset.Version
            );

            if (duplicate) return Conflict();

            MotherboardChipset MotherboardChipset = new(createMotherboardChipset);

            _context.MotherboardChipset.Add(MotherboardChipset);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll(Guid motherboardChipsetUUID)
        {
            HashSet<DTO.Details> MotherboardChipsetDetails = new();

            IAsyncEnumerable<MotherboardChipset> query = _context.MotherboardChipset
                .Include(x => x.Manufacturer)
                .Include(x => x.CPUSocket)
                .Where(x => x.UUID == motherboardChipsetUUID)
                .AsAsyncEnumerable();

            await foreach (MotherboardChipset MotherboardChipset in query)
            {
                MotherboardChipsetDetails.Add(new DTO.Details(MotherboardChipset));
            }

            return Ok(MotherboardChipsetDetails);
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
