using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.PCIEConnector
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class PCIEConnectorController : ControllerBase
    {
        private readonly CCContext _context;

        public PCIEConnectorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createPCIEConnector)
        {
            var errors = createPCIEConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            PCIEConnector? existing = await _context.PCIEConnector.FirstOrDefaultAsync(x => x.UUID == createPCIEConnector.UUID);

            if (existing != null) return Conflict();

            PCIEConnector PCIEConnector = new(createPCIEConnector);

            _context.PCIEConnector.Add(PCIEConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> PCIEConnectors = await _context.PCIEConnector
                .Include(x => x.PCIEGeneration)
                .Select(pcieConnector => new DTO.Details(pcieConnector))
                .ToListAsync();

            return Ok(PCIEConnectors);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            PCIEConnector? PCIEConnector = await _context.PCIEConnector.FirstOrDefaultAsync(PCIEConnector => PCIEConnector.UUID == uuid);

            if (PCIEConnector == null) return NotFound();

            var details = new DTO.Details(PCIEConnector);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit PCIEConnectorEdits)
        {
            IReadOnlyList<string> errors = PCIEConnectorEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            PCIEConnector? PCIEConnector = await _context.PCIEConnector.FirstOrDefaultAsync(x => x.UUID == PCIEConnectorEdits.UUID);

            if (PCIEConnector == null) return NotFound();

            PCIEConnector.Edit(PCIEConnector, PCIEConnectorEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            PCIEConnector? PCIEConnector = await _context.PCIEConnector.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (PCIEConnector == null) return NotFound();

            _context.PCIEConnector.Remove(PCIEConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
