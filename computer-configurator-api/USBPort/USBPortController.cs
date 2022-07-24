using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.USBPort
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
    public class USBPortController : ControllerBase
    {
        private readonly CCContext _context;

        public USBPortController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createUSBPort)
        {
            var errors = createUSBPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            USBPort? existing = await _context.USBPort.FirstOrDefaultAsync(x => x.UUID == createUSBPort.UUID);

            if (existing != null) return Conflict();

            USBPort USBPort = new(createUSBPort);

            _context.USBPort.Add(USBPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> USBPorts = await _context.USBPort
                .Select(usbPorts => new DTO.Details(usbPorts))
                .ToListAsync();

            return Ok(USBPorts);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            USBPort? USBPort = await _context.USBPort.FirstOrDefaultAsync(USBPort => USBPort.UUID == uuid);

            if (USBPort == null) return NotFound();

            var details = new DTO.Details(USBPort);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit USBPortEdits)
        {
            IReadOnlyList<string> errors = USBPortEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            USBPort? USBPort = await _context.USBPort.FirstOrDefaultAsync(x => x.UUID == USBPortEdits.UUID);

            if (USBPort == null) return NotFound();

            USBPort.Edit(USBPort, USBPortEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            USBPort? USBPort = await _context.USBPort.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (USBPort == null) return NotFound();

            _context.USBPort.Remove(USBPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
