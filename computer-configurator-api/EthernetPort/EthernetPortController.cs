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

            EthernetPort? existing = await _context.EthernetPort.FirstOrDefaultAsync(x => x.UUID == createEthernetPort.UUID);

            if (existing != null) return Conflict();

            EthernetPort EthernetPort = new(createEthernetPort);

            _context.EthernetPort.Add(EthernetPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> EthernetPorts = await _context.EthernetPort
                .Select(ethernetPort => new DTO.Details(ethernetPort))
                .ToListAsync();

            return Ok(EthernetPorts);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            EthernetPort? EthernetPort = await _context.EthernetPort.FirstOrDefaultAsync(EthernetPort => EthernetPort.UUID == uuid);

            if (EthernetPort == null) return NotFound();

            var details = new DTO.Details(EthernetPort);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit EthernetPortEdits)
        {
            IReadOnlyList<string> errors = EthernetPortEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            EthernetPort? EthernetPort = await _context.EthernetPort.FirstOrDefaultAsync(x => x.UUID == EthernetPortEdits.UUID);

            if (EthernetPort == null) return NotFound();

            EthernetPort.Edit(EthernetPort, EthernetPortEdits);

            await _context.SaveChangesAsync();

            return NoContent();
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
