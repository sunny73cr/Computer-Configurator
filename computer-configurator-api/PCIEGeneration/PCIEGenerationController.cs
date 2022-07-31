using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.PCIEGeneration
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class PCIEGenerationController : ControllerBase
    {
        private readonly CCContext _context;

        public PCIEGenerationController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createPCIEGeneration)
        {
            var errors = createPCIEGeneration.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool duplicate = await _context.PCIEGeneration.AnyAsync(x => x.Generation == createPCIEGeneration.Generation);

            if (duplicate) return Conflict();

            PCIEGeneration PCIEGeneration = new(createPCIEGeneration);

            _context.PCIEGeneration.Add(PCIEGeneration);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> PCIEGenerations = new();

            IAsyncEnumerable<PCIEGeneration> query = _context.PCIEGeneration
                .AsAsyncEnumerable();

            await foreach (PCIEGeneration pcieGeneration in query)
            {
                PCIEGenerations.Add(new DTO.Details(pcieGeneration));
            }

            return Ok(PCIEGenerations);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            PCIEGeneration? PCIEGeneration = await _context.PCIEGeneration.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (PCIEGeneration == null) return NotFound();

            _context.PCIEGeneration.Remove(PCIEGeneration);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
