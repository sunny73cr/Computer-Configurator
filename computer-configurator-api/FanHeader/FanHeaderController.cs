using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.FanHeader
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
    public class FanHeaderController : ControllerBase
    {
        private readonly CCContext _context;

        public FanHeaderController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createFanHeader)
        {
            var errors = createFanHeader.Validate();

            if (errors.Any()) return BadRequest(errors);

            FanHeader? existing = await _context.FanHeader.FirstOrDefaultAsync(x => x.UUID == createFanHeader.UUID);

            if (existing != null) return Conflict();

            FanHeader FanHeader = new(createFanHeader);

            _context.FanHeader.Add(FanHeader);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> FanHeaders = await _context.FanHeader
                .Select(fanHeader => new DTO.Details(fanHeader))
                .ToListAsync();

            return Ok(FanHeaders);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            FanHeader? FanHeader = await _context.FanHeader.FirstOrDefaultAsync(FanHeader => FanHeader.UUID == uuid);

            if (FanHeader == null) return NotFound();

            var details = new DTO.Details(FanHeader);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit FanHeaderEdits)
        {
            IReadOnlyList<string> errors = FanHeaderEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            FanHeader? FanHeader = await _context.FanHeader.FirstOrDefaultAsync(x => x.UUID == FanHeaderEdits.UUID);

            if (FanHeader == null) return NotFound();

            FanHeader.Edit(FanHeader, FanHeaderEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            FanHeader? FanHeader = await _context.FanHeader.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (FanHeader == null) return NotFound();

            _context.FanHeader.Remove(FanHeader);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
