using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.CPUSocket
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class CPUSocketController : ControllerBase
    {
        private readonly CCContext _context;

        public CPUSocketController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createCPUSocket)
        {
            var errors = createCPUSocket.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool existing = await _context.CPUSocket.AnyAsync(x => x.Version.ToLower() == createCPUSocket.Version.ToLower());

            if (existing) return Conflict();

            CPUSocket cpu = new(createCPUSocket);

            _context.CPUSocket.Add(cpu);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> CPUSockets = new();

            IAsyncEnumerable<CPUSocket> query = _context.CPUSocket
                .AsAsyncEnumerable();

            await foreach (CPUSocket cpuSocket in query)
            {
                CPUSockets.Add(new DTO.Details(cpuSocket));
            }

            return Ok(CPUSockets);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            CPUSocket? CPUSocket = await _context.CPUSocket.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (CPUSocket == null) return NotFound();

            _context.CPUSocket.Remove(CPUSocket);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
