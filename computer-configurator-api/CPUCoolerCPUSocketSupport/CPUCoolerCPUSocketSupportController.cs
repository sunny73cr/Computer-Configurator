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

        [HttpPost]
        public async Task<ActionResult> Create(Guid cpuCoolerUUID, DTO.Create createCPUCoolerCPUSocketSupport)
        {
            IReadOnlyList<string> errors = createCPUCoolerCPUSocketSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool existing = await _context.CPUCoolerCPUSocketSupport.AnyAsync(x =>
                x.CPUCoolerUUID == cpuCoolerUUID
                && x.CPUSocketUUID == createCPUCoolerCPUSocketSupport.CPUSocketUUID
            );

            if (existing) return Conflict();

            bool cpuCoolerExists = await _context.CPUCooler.AnyAsync(x => x.UUID == cpuCoolerUUID);

            if (cpuCoolerExists == false) return NotFound();

            bool cpuSocketExists = await _context.CPUSocket.AnyAsync(x => x.UUID == createCPUCoolerCPUSocketSupport.CPUSocketUUID);

            if (cpuSocketExists == false) return NotFound();

            CPUCoolerCPUSocketSupport CPUCoolerCPUSocketSupport = new(cpuCoolerUUID, createCPUCoolerCPUSocketSupport);

            _context.CPUCoolerCPUSocketSupport.Add(CPUCoolerCPUSocketSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid cpuCoolerUUID)
        {
            List<DTO.Details> CPUCoolerCPUSocketSupport = new();

            IAsyncEnumerable<CPUCoolerCPUSocketSupport> query = _context.CPUCoolerCPUSocketSupport
                .Include(x => x.CPUSocket)
                .Where(x => x.CPUCoolerUUID == cpuCoolerUUID)
                .AsAsyncEnumerable();

            await foreach (CPUCoolerCPUSocketSupport cpuCoolerCPUSocketSupport in query)
            {
                CPUCoolerCPUSocketSupport.Add(new DTO.Details(cpuCoolerCPUSocketSupport));
            }

            return Ok(CPUCoolerCPUSocketSupport);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid cpuCoolerUUID, Guid cpuSocketUUID)
        {
            CPUCoolerCPUSocketSupport? cpuCoolerCPUSocketSupport = await _context.CPUCoolerCPUSocketSupport.FirstOrDefaultAsync(x =>
                x.CPUCoolerUUID == cpuCoolerUUID
                && x.CPUSocketUUID == cpuSocketUUID
            );

            if (cpuCoolerCPUSocketSupport == null) return NotFound();

            _context.CPUCoolerCPUSocketSupport.Remove(cpuCoolerCPUSocketSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
