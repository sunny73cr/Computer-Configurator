using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.RAM
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class RAMController : ControllerBase
    {
        private readonly CCContext _context;

        public RAMController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createRAM)
        {
            var errors = createRAM.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createRAM.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createRAM)) return Conflict();

            bool RAMSocketExists = await _context.RAMSocket.AnyAsync(x => x.UUID == createRAM.RAMSocketUUID);

            if (RAMSocketExists == false) return NotFound();

            bool RAMSpeedExists = await _context.RAMSpeed.AnyAsync(x => x.UUID == createRAM.RAMSpeedUUID);

            if (RAMSpeedExists == false) return NotFound();

            RAM RAM = new(createRAM);

            _context.RAM.Add(RAM);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> RAMs = new();

            IAsyncEnumerable<RAM> query = _context.RAM
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.RAMSocket)
                .Include(x => x.RAMSpeed)
                .AsAsyncEnumerable();

            await foreach (RAM RAM in query)
            {
                RAMs.Add(new DTO.Details(RAM));
            }

            return Ok(RAMs);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            RAM? RAM = await _context.RAM
                .Include(RAM => RAM.Part)
                .ThenInclude(part => part.Manufacturer)
                .Include(RAM => RAM.RAMSocket)
                .Include(RAM => RAM.RAMSpeed)
                .FirstOrDefaultAsync(RAM => RAM.UUID == uuid);

            if (RAM == null) return NotFound();

            var details = new DTO.Details(RAM);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit RAMEdits)
        {
            IReadOnlyList<string> errors = RAMEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            RAM? RAM = await _context.RAM.FirstOrDefaultAsync(x => x.UUID == RAMEdits.UUID);

            if (RAM == null) return NotFound();

            if (RAM.ManufacturerUUID != RAMEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == RAMEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (RAM.Model.ToLower() != RAMEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, RAMEdits);

                    if (duplicate) return Conflict();
                }
            }

            if (RAM.RAMSocketUUID != RAMEdits.RAMSocketUUID)
            {
                bool ramSocketExists = await _context.RAMSocket.AnyAsync(x => x.UUID == RAMEdits.RAMSocketUUID);

                if (ramSocketExists == false) return NotFound();
            }

            if (RAM.RAMSpeedUUID != RAMEdits.RAMSpeedUUID)
            {
                bool ramSpeedExists = await _context.RAMSpeed.AnyAsync(x => x.UUID == RAMEdits.RAMSpeedUUID);

                if (ramSpeedExists == false) return NotFound();
            }

            RAM.Edit(RAM, RAMEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            RAM? RAM = await _context.RAM.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (RAM == null) return NotFound();

            _context.RAM.Remove(RAM);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
