using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.SATAGeneration
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class SATAGenerationController : ControllerBase
    {
        private readonly CCContext _context;

        public SATAGenerationController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createSATAGeneration)
        {
            var errors = createSATAGeneration.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool duplicate = await _context.SATAGeneration.AnyAsync(x => x.Generation == createSATAGeneration.Generation);

            if (duplicate) return Conflict();

            SATAGeneration SATAGeneration = new(createSATAGeneration);

            _context.SATAGeneration.Add(SATAGeneration);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> SATAGenerations = new();

            IAsyncEnumerable<SATAGeneration> query = _context.SATAGeneration
                .AsAsyncEnumerable();

            await foreach (SATAGeneration sataGeneration in query)
            {
                SATAGenerations.Add(new DTO.Details(sataGeneration));
            }

            return Ok(SATAGenerations);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            SATAGeneration? SATAGeneration = await _context.SATAGeneration.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (SATAGeneration == null) return NotFound();

            _context.SATAGeneration.Remove(SATAGeneration);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
