using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.RadiatorSize
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class RadiatorSizeController : ControllerBase
    {
        private readonly CCContext _context;

        public RadiatorSizeController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createRadiatorSize)
        {
            var errors = createRadiatorSize.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool duplicate = await _context.RadiatorSize.AnyAsync(x => x.Size == createRadiatorSize.Size);

            if (duplicate) return Conflict();

            RadiatorSize RadiatorSize = new(createRadiatorSize);

            _context.RadiatorSize.Add(RadiatorSize);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> RadiatorSizes = new();

            IAsyncEnumerable<RadiatorSize> query = _context.RadiatorSize
                .AsAsyncEnumerable();

            await foreach (RadiatorSize radiatorSize in query)
            {
                RadiatorSizes.Add(new DTO.Details(radiatorSize));
            }

            return Ok(RadiatorSizes);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            RadiatorSize? RadiatorSize = await _context.RadiatorSize.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (RadiatorSize == null) return NotFound();

            _context.RadiatorSize.Remove(RadiatorSize);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
