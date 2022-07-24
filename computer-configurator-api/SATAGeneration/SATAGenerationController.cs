using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.SATAGeneration
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
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

            SATAGeneration? existing = await _context.SATAGeneration.FirstOrDefaultAsync(x => x.UUID == createSATAGeneration.UUID);

            if (existing != null) return Conflict();

            SATAGeneration SATAGeneration = new(createSATAGeneration);

            _context.SATAGeneration.Add(SATAGeneration);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> SATAGenerations = await _context.SATAGeneration
                .Select(sataGeneration => new DTO.Details(sataGeneration))
                .ToListAsync();

            return Ok(SATAGenerations);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            SATAGeneration? SATAGeneration = await _context.SATAGeneration.FirstOrDefaultAsync(SATAGeneration => SATAGeneration.UUID == uuid);

            if (SATAGeneration == null) return NotFound();

            var details = new DTO.Details(SATAGeneration);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit SATAGenerationEdits)
        {
            IReadOnlyList<string> errors = SATAGenerationEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            SATAGeneration? SATAGeneration = await _context.SATAGeneration.FirstOrDefaultAsync(x => x.UUID == SATAGenerationEdits.UUID);

            if (SATAGeneration == null) return NotFound();

            SATAGeneration.Edit(SATAGeneration, SATAGenerationEdits);

            await _context.SaveChangesAsync();

            return NoContent();
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
