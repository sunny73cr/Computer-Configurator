using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.BenchmarkedResolution
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class BenchmarkedResolutionController : ControllerBase
    {
        private readonly CCContext _context;

        public BenchmarkedResolutionController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createBenchmarkedResolution)
        {
            var errors = createBenchmarkedResolution.Validate();

            if (errors.Any()) return BadRequest(errors);

            BenchmarkedResolution? existing = await _context.BenchmarkedResolution.FirstOrDefaultAsync(x => x.UUID == createBenchmarkedResolution.UUID);

            if (existing != null) return Conflict();

            BenchmarkedResolution BenchmarkedResolution = new(createBenchmarkedResolution);

            _context.BenchmarkedResolution.Add(BenchmarkedResolution);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> BenchmarkedResolutions = await _context.BenchmarkedResolution
                .Select(benchmarkedResolution => new DTO.Details(benchmarkedResolution))
                .ToListAsync();

            return Ok(BenchmarkedResolutions);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            BenchmarkedResolution? BenchmarkedResolution = await _context.BenchmarkedResolution.FirstOrDefaultAsync(BenchmarkedResolution => BenchmarkedResolution.UUID == uuid);

            if (BenchmarkedResolution == null) return NotFound();

            var details = new DTO.Details(BenchmarkedResolution);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit BenchmarkedResolutionEdits)
        {
            IReadOnlyList<string> errors = BenchmarkedResolutionEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            BenchmarkedResolution? BenchmarkedResolution = await _context.BenchmarkedResolution.FirstOrDefaultAsync(x => x.UUID == BenchmarkedResolutionEdits.UUID);

            if (BenchmarkedResolution == null) return NotFound();

            BenchmarkedResolution.Edit(BenchmarkedResolution, BenchmarkedResolutionEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            BenchmarkedResolution? BenchmarkedResolution = await _context.BenchmarkedResolution.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (BenchmarkedResolution == null) return NotFound();

            _context.BenchmarkedResolution.Remove(BenchmarkedResolution);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
