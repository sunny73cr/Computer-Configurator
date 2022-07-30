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
            IReadOnlyList<string> errors = createDisplayConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool existing = await _context.DisplayConnector.AnyAsync(x =>
                x.Version == createDisplayConnector.Version
                && x.Interface == x.Interface
            );

            if (existing) return Conflict();

            DisplayConnector DisplayConnector = new(createDisplayConnector);

            _context.DisplayConnector.Add(DisplayConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> DisplayConnectors = new();

            IAsyncEnumerable<DisplayConnector> query = _context.DisplayConnector
               .AsAsyncEnumerable();

            await foreach (DisplayConnector displayConnector in query)
            {
                DisplayConnectors.Add(new DTO.Details(displayConnector));
            }

            return Ok(DisplayConnectors);
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
