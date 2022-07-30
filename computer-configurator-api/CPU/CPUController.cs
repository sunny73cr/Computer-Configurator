using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.CPU
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class CPUController : ControllerBase
    {
        private readonly CCContext _context;

        public CPUController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createCPU)
        {
            var errors = createCPU.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createCPU.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createCPU)) return Conflict();

            bool cpuSocketExists = await _context.CPUSocket.AnyAsync(x => x.UUID == createCPU.CPUSocketUUID);

            if (cpuSocketExists == false) return NotFound();

            CPU cpu = new(createCPU);

            _context.CPU.Add(cpu);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> CPUs = new();

            IAsyncEnumerable<CPU> query = _context.CPU
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.CPUSocket)
                .AsAsyncEnumerable();

            await foreach (CPU cpu in query)
            {
                CPUs.Add(new DTO.Details(cpu));
            }

            return Ok(CPUs);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            CPU? cpu = await _context.CPU
                .Include(cpu => cpu.CPUSocket)
                .Include(cpu => cpu.Part)
                .ThenInclude(part => part.Manufacturer)
                .FirstOrDefaultAsync(cpu => cpu.UUID == uuid);

            if (cpu == null) return NotFound();

            var details = new DTO.Details(cpu);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit cpuEdits)
        {
            IReadOnlyList<string> errors = cpuEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            CPU? cpu = await _context.CPU.FirstOrDefaultAsync(x => x.UUID == cpuEdits.UUID);

            if (cpu == null) return NotFound();

            if (cpu.ManufacturerUUID != cpuEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == cpuEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (cpu.Model.ToLower() != cpuEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, cpuEdits);

                    if (duplicate) return Conflict();
                }
            }

            if (cpu.CPUSocketUUID != cpuEdits.CPUSocketUUID)
            {
                bool exists = await _context.CPUSocket.AnyAsync(x => x.UUID == cpuEdits.CPUSocketUUID);

                if (exists == false) return NotFound();
            }

            CPU.Edit(cpu, cpuEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            CPU? cpu = await _context.CPU.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (cpu == null) return NotFound();

            _context.CPU.Remove(cpu);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
