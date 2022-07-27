using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.CPUClosedLoopCooler
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class CPUClosedLoopCoolerController : ControllerBase
    {
        private readonly CCContext _context;

        public CPUClosedLoopCoolerController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createCPUClosedLoopCooler)
        {
            var errors = createCPUClosedLoopCooler.Validate();

            if (errors.Any()) return BadRequest(errors);

            CPUClosedLoopCooler? existing = await _context.CPUClosedLoopCooler.FirstOrDefaultAsync(x => x.UUID == createCPUClosedLoopCooler.UUID);

            if (existing != null) return Conflict();

            RadiatorSize.RadiatorSize? radiatorSize = await _context.RadiatorSize.FirstOrDefaultAsync(x => x.UUID == createCPUClosedLoopCooler.RadiatorSizeUUID);

            if (radiatorSize == null) return NotFound();

            foreach (CPUCoolerFan.DTO.Create createCPUCoolerFan in createCPUClosedLoopCooler.CPUCoolerFans)
            {
                Fan.Fan? fan = await _context.Fan.FirstOrDefaultAsync(x => x.UUID == createCPUCoolerFan.FanUUID);

                if (fan == null) return NotFound();
            }

            foreach (CPUCoolerCPUSocketSupport.DTO.Create createCPUCoolerSocketSupport in createCPUClosedLoopCooler.CPUCoolerCPUSocketSupport)
            {
                CPUSocket.CPUSocket? cpuSocket = await _context.CPUSocket.FirstOrDefaultAsync(x => x.UUID == createCPUCoolerSocketSupport.CPUSocketUUID);

                if (cpuSocket == null) return NotFound();
            }

            CPUClosedLoopCooler CPUClosedLoopCooler = new(createCPUClosedLoopCooler);

            _context.CPUClosedLoopCooler.Add(CPUClosedLoopCooler);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            DTO.Details? CPUClosedLoopCooler = await _context.CPUClosedLoopCooler
                .Include(x => x.CPUSockets)
                .Include(x => x.CPUCoolerFans)
                .Include(x => x.RadiatorSize)
                .Include(CPUClosedLoopCooler => CPUClosedLoopCooler.Part)
                .ThenInclude(part => part.Manufacturer)
                .Select(CPUClosedLoopCooler => new DTO.Details(CPUClosedLoopCooler))
                .FirstOrDefaultAsync(CPUClosedLoopCooler => CPUClosedLoopCooler.UUID == uuid);

            if (CPUClosedLoopCooler == null) return NotFound();

            return Ok(CPUClosedLoopCooler);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit CPUClosedLoopCoolerEdits)
        {
            IReadOnlyList<string> errors = CPUClosedLoopCoolerEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            CPUClosedLoopCooler? CPUClosedLoopCooler = await _context.CPUClosedLoopCooler.FirstOrDefaultAsync(x => x.UUID == CPUClosedLoopCoolerEdits.UUID);

            if (CPUClosedLoopCooler == null) return NotFound();

            CPUClosedLoopCooler.Edit(CPUClosedLoopCooler, CPUClosedLoopCoolerEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            CPUClosedLoopCooler? placeholder = await _context.CPUClosedLoopCooler.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (placeholder == null) return NotFound();

            _context.CPUClosedLoopCooler.Remove(placeholder);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
