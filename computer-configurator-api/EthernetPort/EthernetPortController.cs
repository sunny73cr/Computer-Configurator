using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.EthernetPort
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class EthernetPortController : ControllerBase
    {
        private readonly CCContext _context;

        public EthernetPortController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createEthernetPort)
        {
            var errors = createEthernetPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool existing = await _context.EthernetPort.AnyAsync(x => x.Chipset == createEthernetPort.Chipset);

            if (existing) return Conflict();

            EthernetPort EthernetPort = new(createEthernetPort);

            _context.EthernetPort.Add(EthernetPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> EthernetPorts = new();

            IAsyncEnumerable<EthernetPort> query = _context.EthernetPort
                .AsAsyncEnumerable();

            await foreach (EthernetPort ethernetPort in query)
            {
                EthernetPorts.Add(new DTO.Details(ethernetPort));
            }

            return Ok(EthernetPorts);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            EthernetPort? EthernetPort = await _context.EthernetPort.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (EthernetPort == null) return NotFound();

            _context.EthernetPort.Remove(EthernetPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
