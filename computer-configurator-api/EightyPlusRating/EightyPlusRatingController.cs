using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.EightyPlusRating
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
    public class EightyPlusRatingController : ControllerBase
    {
        private readonly CCContext _context;

        public EightyPlusRatingController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createEightyPlusRating)
        {
            var errors = createEightyPlusRating.Validate();

            if (errors.Any()) return BadRequest(errors);

            EightyPlusRating? existing = await _context.EightyPlusRating.FirstOrDefaultAsync(x => x.UUID == createEightyPlusRating.UUID);

            if (existing != null) return Conflict();

            EightyPlusRating EightyPlusRating = new(createEightyPlusRating);

            _context.EightyPlusRating.Add(EightyPlusRating);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> EightyPlusRatings = await _context.EightyPlusRating
                .Select(eightyPlusRating => new DTO.Details(eightyPlusRating))
                .ToListAsync();

            return Ok(EightyPlusRatings);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            EightyPlusRating? EightyPlusRating = await _context.EightyPlusRating.FirstOrDefaultAsync(EightyPlusRating => EightyPlusRating.UUID == uuid);

            if (EightyPlusRating == null) return NotFound();

            var details = new DTO.Details(EightyPlusRating);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit EightyPlusRatingEdits)
        {
            IReadOnlyList<string> errors = EightyPlusRatingEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            EightyPlusRating? EightyPlusRating = await _context.EightyPlusRating.FirstOrDefaultAsync(x => x.UUID == EightyPlusRatingEdits.UUID);

            if (EightyPlusRating == null) return NotFound();

            EightyPlusRating.Edit(EightyPlusRating, EightyPlusRatingEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            EightyPlusRating? EightyPlusRating = await _context.EightyPlusRating.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (EightyPlusRating == null) return NotFound();

            _context.EightyPlusRating.Remove(EightyPlusRating);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
