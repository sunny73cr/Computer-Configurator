using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.CPUCoolerCPUSocketSupport
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class CPUCoolerCPUSocketSupportController : ControllerBase
    {
        private readonly CCContext _context;

        public CPUCoolerCPUSocketSupportController(CCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid cpuCoolerUUID)
        {
            List<DTO.Details> CPUCoolerCPUSocketSupports = await _context.CPUCoolerCPUSocketSupport
                .Include(x => x.CPUSocket)
                .Where(x => x.CPUCoolerUUID == cpuCoolerUUID)
                .Select(CPUCoolerCPUSocketSupport => new DTO.Details(CPUCoolerCPUSocketSupport))
                .ToListAsync();

            return Ok(CPUCoolerCPUSocketSupports);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid cpuCoolerUUID, DTO.Create createCPUCoolerCPUSocketSupport)
        {
            IReadOnlyList<string> errors = createCPUCoolerCPUSocketSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            CPUCoolerCPUSocketSupport? existing = await _context.CPUCoolerCPUSocketSupport.FirstOrDefaultAsync(x =>
                x.CPUCoolerUUID == cpuCoolerUUID
                && x.CPUSocketUUID == createCPUCoolerCPUSocketSupport.CPUSocketUUID
            );

            if (existing != null) return Conflict();

            CPUCooler.CPUCooler? cpuCooler = await _context.CPUCooler.FirstOrDefaultAsync(x => x.UUID == cpuCoolerUUID);

            if (cpuCooler == null) return NotFound();

            CPUSocket.CPUSocket? cpuSocket = await _context.CPUSocket.FirstOrDefaultAsync(x => x.UUID == createCPUCoolerCPUSocketSupport.CPUSocketUUID);

            if (cpuSocket == null) return NotFound();

            CPUCoolerCPUSocketSupport CPUCoolerCPUSocketSupport = new(cpuCoolerUUID, createCPUCoolerCPUSocketSupport);

            _context.CPUCoolerCPUSocketSupport.Add(CPUCoolerCPUSocketSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid cpuCoolerUUID, Guid cpuSocketUUID)
        {
            CPUCoolerCPUSocketSupport? existing = await _context.CPUCoolerCPUSocketSupport.FirstOrDefaultAsync(x =>
                x.CPUCoolerUUID == cpuCoolerUUID
                && x.CPUSocketUUID == cpuSocketUUID
            );

            if (existing == null) return NotFound();

            _context.CPUCoolerCPUSocketSupport.Remove(existing);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
