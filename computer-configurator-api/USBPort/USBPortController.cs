using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.USBPort
{
    [ApiController]
    [Route("/[controller]/[action]/")]
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

            bool duplicate = await _context.USBPort.AnyAsync(x =>
                x.Interface == createUSBPort.Interface
                && x.Version == createUSBPort.Version
            );

            if (duplicate) return Conflict();

            USBPort USBPort = new(createUSBPort);

            _context.USBPort.Add(USBPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> USBPorts = new();

            IAsyncEnumerable<USBPort> query = _context.USBPort
                .AsAsyncEnumerable();

            await foreach (USBPort usbPort in query)
            {
                USBPorts.Add(new DTO.Details(usbPort));
            }

            return Ok(USBPorts);
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
