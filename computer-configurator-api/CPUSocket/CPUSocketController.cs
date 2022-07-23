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

            CPUSocket? existing = await _context.CPUSocket.FirstOrDefaultAsync(x => x.UUID == createCPUSocket.UUID);

            if (existing != null) return Conflict();

            CPUSocket cpu = new(createCPUSocket);

            _context.CPUSocket.Add(cpu);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<CPUSocket> CPUSockets = await _context.CPUSocket.ToListAsync();

            List<DTO.Details> detailsCPUSockets = CPUSockets
                .Select(cpuSocket => new DTO.Details(cpuSocket))
                .ToList();

            return Ok(detailsCPUSockets);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByVersion(string version)
        {
            CPUSocket? CPUSocket = await _context.CPUSocket.FirstOrDefaultAsync(x => x.Version == version);

            if (CPUSocket == null) return NotFound();

            var details = new DTO.Details(CPUSocket);

            return Ok(details);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            CPUSocket? CPUSocket = await _context.CPUSocket.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (CPUSocket == null) return NotFound();

            var details = new DTO.Details(CPUSocket);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit editsCPUSocket)
        {
            IReadOnlyList<string> errors = editsCPUSocket.Validate();

            if (errors.Any()) return BadRequest(errors);

            CPUSocket? CPUSocket = await _context.CPUSocket.FirstOrDefaultAsync(x => x.UUID == editsCPUSocket.UUID);

            if (CPUSocket == null) return NotFound();

            CPUSocket.Edit(CPUSocket, editsCPUSocket);

            await _context.SaveChangesAsync();

            return NoContent();
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
