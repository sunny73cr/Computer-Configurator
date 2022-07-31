using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.EightyPlusRating
{
    [ApiController]
    [Route("/[controller]/[action]/")]
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

            bool existing = await _context.EightyPlusRating.AnyAsync(x => x.Rating == createEightyPlusRating.Rating);

            if (existing) return Conflict();

            EightyPlusRating EightyPlusRating = new(createEightyPlusRating);

            _context.EightyPlusRating.Add(EightyPlusRating);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> EightyPlusRatings = new();

            IAsyncEnumerable<EightyPlusRating> query = _context.EightyPlusRating
                .AsAsyncEnumerable();

            await foreach (EightyPlusRating eightyPlusRating in query)
            {
                EightyPlusRatings.Add(new DTO.Details(eightyPlusRating));
            }

            return Ok(EightyPlusRatings);
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
