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

            CPU? existing = await _context.CPU.FirstOrDefaultAsync(x => x.UUID == createCPU.UUID);

            if (existing != null) return Conflict();

            CPU cpu = new(createCPU);

            _context.CPU.Add(cpu);

            await _context.SaveChangesAsync();

            return NoContent();
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

            CPU.Edit(cpu, cpuEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            CPU? placeholder = await _context.CPU.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (placeholder == null) return NotFound();

            _context.CPU.Remove(placeholder);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
