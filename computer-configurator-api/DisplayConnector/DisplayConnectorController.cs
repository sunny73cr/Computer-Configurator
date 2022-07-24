using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.DisplayConnector
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class DisplayConnectorController : ControllerBase
    {
        private readonly CCContext _context;

        public DisplayConnectorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createDisplayConnector)
        {
            var errors = createDisplayConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            DisplayConnector? existing = await _context.DisplayConnector.FirstOrDefaultAsync(x => x.UUID == createDisplayConnector.UUID);

            if (existing != null) return Conflict();

            DisplayConnector DisplayConnector = new(createDisplayConnector);

            _context.DisplayConnector.Add(DisplayConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> DisplayConnectors = await _context.DisplayConnector
                .Select(displayConnector => new DTO.Details(displayConnector))
                .ToListAsync();

            return Ok(DisplayConnectors);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            DisplayConnector? DisplayConnector = await _context.DisplayConnector.FirstOrDefaultAsync(DisplayConnector => DisplayConnector.UUID == uuid);

            if (DisplayConnector == null) return NotFound();

            var details = new DTO.Details(DisplayConnector);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit DisplayConnectorEdits)
        {
            IReadOnlyList<string> errors = DisplayConnectorEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            DisplayConnector? DisplayConnector = await _context.DisplayConnector.FirstOrDefaultAsync(x => x.UUID == DisplayConnectorEdits.UUID);

            if (DisplayConnector == null) return NotFound();

            DisplayConnector.Edit(DisplayConnector, DisplayConnectorEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            DisplayConnector? DisplayConnector = await _context.DisplayConnector.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (DisplayConnector == null) return NotFound();

            _context.DisplayConnector.Remove(DisplayConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
