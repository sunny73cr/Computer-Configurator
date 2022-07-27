using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.CPUHeatsink
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class CPUHeatsinkController : ControllerBase
    {
        private readonly CCContext _context;

        public CPUHeatsinkController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createCPUHeatsink)
        {
            var errors = createCPUHeatsink.Validate();

            if (errors.Any()) return BadRequest(errors);

            CPUHeatsink? existing = await _context.CPUHeatsink.FirstOrDefaultAsync(x => x.UUID == createCPUHeatsink.UUID);

            if (existing != null) return Conflict();

            foreach (CPUCoolerFan.DTO.Create createCPUCoolerFan in createCPUHeatsink.CPUCoolerFans)
            {
                Fan.Fan? fan = await _context.Fan.FirstOrDefaultAsync(x => x.UUID == createCPUCoolerFan.FanUUID);

                if (fan == null) return NotFound();
            }

            foreach (CPUCoolerCPUSocketSupport.DTO.Create createCPUCoolerSocketSupport in createCPUHeatsink.CPUCoolerCPUSocketSupport)
            {
                CPUSocket.CPUSocket? cpuSocket = await _context.CPUSocket.FirstOrDefaultAsync(x => x.UUID == createCPUCoolerSocketSupport.CPUSocketUUID);

                if (cpuSocket == null) return NotFound();
            }

            CPUHeatsink CPUHeatsink = new(createCPUHeatsink);

            _context.CPUHeatsink.Add(CPUHeatsink);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            DTO.Details? CPUHeatsink = await _context.CPUHeatsink
                .Include(x => x.CPUSockets)
                .Include(x => x.CPUCoolerFans)
                .Include(CPUHeatsink => CPUHeatsink.Part)
                .ThenInclude(part => part.Manufacturer)
                .Select(CPUHeatsink => new DTO.Details(CPUHeatsink))
                .FirstOrDefaultAsync(CPUHeatsink => CPUHeatsink.UUID == uuid);

            if (CPUHeatsink == null) return NotFound();

            return Ok(CPUHeatsink);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit CPUHeatsinkEdits)
        {
            IReadOnlyList<string> errors = CPUHeatsinkEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            CPUHeatsink? CPUHeatsink = await _context.CPUHeatsink.FirstOrDefaultAsync(x => x.UUID == CPUHeatsinkEdits.UUID);

            if (CPUHeatsink == null) return NotFound();

            CPUHeatsink.Edit(CPUHeatsink, CPUHeatsinkEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            CPUHeatsink? placeholder = await _context.CPUHeatsink.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (placeholder == null) return NotFound();

            _context.CPUHeatsink.Remove(placeholder);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
