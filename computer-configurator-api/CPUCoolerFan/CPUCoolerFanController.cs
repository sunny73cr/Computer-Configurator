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

            bool cpuCoolerExists = await _context.CPUCooler.AnyAsync(x => x.UUID == cpuCoolerUUID);

            if (cpuCoolerExists == false) return NotFound();

            bool fanExists = await _context.Fan.AnyAsync(x => x.UUID == createCPUCoolerFan.FanUUID);

            if (fanExists == false) return NotFound();

            CPUCoolerFan CPUCoolerFan = new(cpuCoolerUUID, createCPUCoolerFan);

            _context.CPUCoolerFan.Add(CPUCoolerFan);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid cpuCoolerUUID)
        {
            List<DTO.Details> CPUCoolerFans = new();

            IAsyncEnumerable<CPUCoolerFan> query = _context.CPUCoolerFan
                .Include(x => x.Fan)
                .ThenInclude(x => x.FanDiameter)
                .Include(x => x.Fan)
                .ThenInclude(x => x.FanVoltage)
                .Where(x => x.CPUCoolerUUID == cpuCoolerUUID)
                .AsAsyncEnumerable();

            await foreach (CPUCoolerFan cpuCoolerFan in query)
            {
                CPUCoolerFans.Add(new DTO.Details(cpuCoolerFan));
            }

            return Ok(CPUCoolerFans);
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
            CPUCoolerFan? cpuCoolerFan = await _context.CPUCoolerFan.FirstOrDefaultAsync(x =>
                x.CPUCoolerUUID == cpuCoolerUUID
                && x.FanUUID == fanUUID
            );

            if (cpuCoolerFan == null) return NotFound();

            _context.CPUCoolerFan.Remove(cpuCoolerFan);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
