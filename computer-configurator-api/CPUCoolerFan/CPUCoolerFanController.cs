using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.CPUCoolerFan
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class CPUCoolerFanController : ControllerBase
    {
        private readonly CCContext _context;

        public CPUCoolerFanController(CCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid cpuCoolerUUID)
        {
            List<DTO.Details> CPUCoolerFans = await _context.CPUCoolerFan
                .Include(x => x.Fan)
                .ThenInclude(x => x.FanDiameter)
                .Include(x => x.Fan)
                .ThenInclude(x => x.FanVoltage)
                .Where(x => x.CPUCoolerUUID == cpuCoolerUUID)
                .Select(CPUCoolerFan => new DTO.Details(CPUCoolerFan))
                .ToListAsync();

            return Ok(CPUCoolerFans);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid cpuCoolerUUID, DTO.Create createCPUCoolerFan)
        {
            IReadOnlyList<string> errors = createCPUCoolerFan.Validate();

            if (errors.Any()) return BadRequest(errors);

            CPUCoolerFan? existing = await _context.CPUCoolerFan.FirstOrDefaultAsync(x =>
                x.CPUCoolerUUID == cpuCoolerUUID
                && x.FanUUID == createCPUCoolerFan.FanUUID
            );

            if (existing != null) return Conflict();

            CPUCooler.CPUCooler? cpuCooler = await _context.CPUCooler.FirstOrDefaultAsync(x => x.UUID == cpuCoolerUUID);

            if (cpuCooler == null) return NotFound();

            Fan.Fan? fan = await _context.Fan.FirstOrDefaultAsync(x => x.UUID == createCPUCoolerFan.FanUUID);

            if (fan == null) return NotFound();

            CPUCoolerFan CPUCoolerFan = new(cpuCoolerUUID, createCPUCoolerFan);

            _context.CPUCoolerFan.Add(CPUCoolerFan);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid cpuCoolerUUID, DTO.Edit editCPUCoolerFan)
        {
            IReadOnlyList<string> errors = editCPUCoolerFan.Validate();

            if (errors.Any()) return BadRequest(errors);

            CPUCoolerFan? cpuCoolerFan = await _context.CPUCoolerFan.FirstOrDefaultAsync(x =>
                x.CPUCoolerUUID == cpuCoolerUUID
                && x.FanUUID == editCPUCoolerFan.FanUUID
            );

            if (cpuCoolerFan == null) return NotFound();

            CPUCoolerFan.Edit(cpuCoolerFan, editCPUCoolerFan);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid cpuCoolerUUID, Guid fanUUID)
        {
            CPUCoolerFan? existing = await _context.CPUCoolerFan.FirstOrDefaultAsync(x =>
                x.CPUCoolerUUID == cpuCoolerUUID
                && x.FanUUID == fanUUID
            );

            if (existing == null) return NotFound();

            _context.CPUCoolerFan.Remove(existing);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
