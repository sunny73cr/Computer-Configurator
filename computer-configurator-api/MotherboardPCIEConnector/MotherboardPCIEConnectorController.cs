using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardPCIEConnector
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class MotherboardPCIEConnectorController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardPCIEConnectorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid motherboardUUID, DTO.Create createMotherboardPCIEConnector)
        {
            IReadOnlyList<string> errors = createMotherboardPCIEConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool motherboardExists = await _context.Motherboard.AnyAsync(x => x.UUID == motherboardUUID);

            if (motherboardExists == false) return NotFound();

            bool pcieConnectorExists = await _context.DisplayConnector.AnyAsync(x => x.UUID == createMotherboardPCIEConnector.PCIEConnectorUUID);

            if (pcieConnectorExists == false) return NotFound();

            bool duplicate = await _context.MotherboardPCIEConnector.AnyAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.PCIEConnectorUUID == createMotherboardPCIEConnector.PCIEConnectorUUID
            );

            if (duplicate) return Conflict();

            MotherboardPCIEConnector MotherboardPCIEConnector = new(motherboardUUID, createMotherboardPCIEConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll(Guid motherboardUUID)
        {
            HashSet<DTO.Details> MotherboardPCIEConnectorDetails = new();

            IAsyncEnumerable<MotherboardPCIEConnector> query = _context.MotherboardPCIEConnector
                .Include(x => x.PCIEConnector)
                .Where(x => x.MotherboardUUID == motherboardUUID)
                .AsAsyncEnumerable();

            await foreach (MotherboardPCIEConnector MotherboardPCIEConnector in query)
            {
                MotherboardPCIEConnectorDetails.Add(new DTO.Details(MotherboardPCIEConnector));
            }

            return Ok(MotherboardPCIEConnectorDetails);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid motherboardUUID, Guid MotherboardPCIEConnectorUUID)
        {
            MotherboardPCIEConnector? MotherboardPCIEConnector = await _context.MotherboardPCIEConnector
                .Include(x => x.PCIEConnector)
                .FirstOrDefaultAsync(
                    x => x.MotherboardUUID == motherboardUUID
                    && x.PCIEConnectorUUID == MotherboardPCIEConnectorUUID
                );

            if (MotherboardPCIEConnector == null) return NotFound();

            DTO.Details MotherboardPCIEConnectorDetails = new(MotherboardPCIEConnector);

            return Ok(MotherboardPCIEConnectorDetails);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid motherboardUUID, DTO.Edit editMotherboardPCIEConnector)
        {
            IReadOnlyList<string> errors = editMotherboardPCIEConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardPCIEConnector? MotherboardPCIEConnector = await _context.MotherboardPCIEConnector.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.PCIEConnectorUUID == editMotherboardPCIEConnector.PCIEConnectorUUID
            );

            if (MotherboardPCIEConnector == null) return NotFound();

            MotherboardPCIEConnector.Edit(MotherboardPCIEConnector, editMotherboardPCIEConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid motherboardUUID, Guid MotherboardPCIEConnectorUUID)
        {
            MotherboardPCIEConnector? MotherboardPCIEConnector = await _context.MotherboardPCIEConnector.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.PCIEConnectorUUID == MotherboardPCIEConnectorUUID
            );

            if (MotherboardPCIEConnector == null) return NotFound();

            _context.MotherboardPCIEConnector.Remove(MotherboardPCIEConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

