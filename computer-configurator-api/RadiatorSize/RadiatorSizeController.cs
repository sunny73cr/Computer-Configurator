using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.RadiatorSize
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
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

            RadiatorSize? existing = await _context.RadiatorSize.FirstOrDefaultAsync(x => x.UUID == createRadiatorSize.UUID);

            if (existing != null) return Conflict();

            RadiatorSize RadiatorSize = new(createRadiatorSize);

            _context.RadiatorSize.Add(RadiatorSize);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> RadiatorSizes = await _context.RadiatorSize
                .Select(radiatorSize => new DTO.Details(radiatorSize))
                .ToListAsync();

            return Ok(RadiatorSizes);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            RadiatorSize? RadiatorSize = await _context.RadiatorSize.FirstOrDefaultAsync(RadiatorSize => RadiatorSize.UUID == uuid);

            if (RadiatorSize == null) return NotFound();

            var details = new DTO.Details(RadiatorSize);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit RadiatorSizeEdits)
        {
            IReadOnlyList<string> errors = RadiatorSizeEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            RadiatorSize? RadiatorSize = await _context.RadiatorSize.FirstOrDefaultAsync(x => x.UUID == RadiatorSizeEdits.UUID);

            if (RadiatorSize == null) return NotFound();

            RadiatorSize.Edit(RadiatorSize, RadiatorSizeEdits);

            await _context.SaveChangesAsync();

            return NoContent();
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
