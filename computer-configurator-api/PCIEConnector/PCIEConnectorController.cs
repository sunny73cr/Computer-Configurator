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

            bool pcieGenerationExists = await _context.PCIEGeneration.AnyAsync(x => x.UUID == createPCIEConnector.PCIEGenerationUUID);

            if (pcieGenerationExists == false) return NotFound();

            bool duplicate = await _context.PCIEConnector.AnyAsync(x =>
                x.LaneCount == createPCIEConnector.LaneCount
                && x.PCIEGenerationUUID == createPCIEConnector.PCIEGenerationUUID
            );

            if (duplicate) return Conflict();

            PCIEConnector PCIEConnector = new(createPCIEConnector);

            _context.PCIEConnector.Add(PCIEConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> PCIEConnectors = new();

            IAsyncEnumerable<PCIEConnector> query = _context.PCIEConnector
                .Include(x => x.PCIEGeneration)
                .AsAsyncEnumerable();

            await foreach (PCIEConnector pcieConnector in query)
            {
                PCIEConnectors.Add(new DTO.Details(pcieConnector));
            }

            return Ok(PCIEConnectors);
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
