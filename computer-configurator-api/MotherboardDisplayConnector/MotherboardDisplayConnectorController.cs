using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardDisplayConnector
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class MotherboardDisplayConnectorController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardDisplayConnectorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid motherboardUUID, DTO.Create createMotherboardDisplayConnector)
        {
            IReadOnlyList<string> errors = createMotherboardDisplayConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool motherboardExists = await _context.Motherboard.AnyAsync(x => x.UUID == motherboardUUID);

            if (motherboardExists == false) return NotFound();

            bool displayConnectorExists = await _context.DisplayConnector.AnyAsync(x => x.UUID == createMotherboardDisplayConnector.DisplayConnectorUUID);

            if (displayConnectorExists == false) return NotFound();

            bool existing = await _context.MotherboardDisplayConnector.AnyAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.DisplayConnectorUUID == createMotherboardDisplayConnector.DisplayConnectorUUID
            );

            if (existing) return Conflict();

            MotherboardDisplayConnector MotherboardDisplayConnector = new(motherboardUUID, createMotherboardDisplayConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll(Guid motherboardUUID)
        {
            HashSet<DTO.Details> MotherboardDisplayConnectorDetails = new();

            IAsyncEnumerable<MotherboardDisplayConnector> query = _context.MotherboardDisplayConnector
                .Include(x => x.DisplayConnector)
                .Where(x => x.MotherboardUUID == motherboardUUID)
                .AsAsyncEnumerable();

            await foreach (MotherboardDisplayConnector MotherboardDisplayConnector in query)
            {
                MotherboardDisplayConnectorDetails.Add(new DTO.Details(MotherboardDisplayConnector));
            }

            return Ok(MotherboardDisplayConnectorDetails);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid motherboardUUID, Guid MotherboardDisplayConnectorUUID)
        {
            MotherboardDisplayConnector? MotherboardDisplayConnector = await _context.MotherboardDisplayConnector
                .Include(x => x.DisplayConnector)
                .FirstOrDefaultAsync(
                    x => x.MotherboardUUID == motherboardUUID
                    && x.DisplayConnectorUUID == MotherboardDisplayConnectorUUID
                );

            if (MotherboardDisplayConnector == null) return NotFound();

            DTO.Details MotherboardDisplayConnectorDetails = new(MotherboardDisplayConnector);

            return Ok(MotherboardDisplayConnectorDetails);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid motherboardUUID, DTO.Edit editMotherboardDisplayConnector)
        {
            IReadOnlyList<string> errors = editMotherboardDisplayConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardDisplayConnector? MotherboardDisplayConnector = await _context.MotherboardDisplayConnector.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.DisplayConnectorUUID == editMotherboardDisplayConnector.DisplayConnectorUUID
            );

            if (MotherboardDisplayConnector == null) return NotFound();

            MotherboardDisplayConnector.Edit(MotherboardDisplayConnector, editMotherboardDisplayConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid motherboardUUID, Guid MotherboardDisplayConnectorUUID)
        {
            MotherboardDisplayConnector? MotherboardDisplayConnector = await _context.MotherboardDisplayConnector.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.DisplayConnectorUUID == MotherboardDisplayConnectorUUID
            );

            if (MotherboardDisplayConnector == null) return NotFound();

            _context.MotherboardDisplayConnector.Remove(MotherboardDisplayConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
