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

            bool existing = await _context.BenchmarkedResolution.AnyAsync(x =>
                x.PixelWidth == createBenchmarkedResolution.PixelWidth
                && x.PixelHeight == createBenchmarkedResolution.PixelHeight
            );

            if (existing) return Conflict();

            BenchmarkedResolution BenchmarkedResolution = new(createBenchmarkedResolution);

            _context.BenchmarkedResolution.Add(BenchmarkedResolution);

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
