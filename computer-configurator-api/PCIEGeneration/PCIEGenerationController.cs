using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.PCIEGeneration
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
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

            PCIEGeneration? existing = await _context.PCIEGeneration.FirstOrDefaultAsync(x => x.UUID == createPCIEGeneration.UUID);

            if (existing != null) return Conflict();

            PCIEGeneration PCIEGeneration = new(createPCIEGeneration);

            _context.PCIEGeneration.Add(PCIEGeneration);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> PCIEGenerations = await _context.PCIEGeneration
                .Select(pcieGeneration => new DTO.Details(pcieGeneration))
                .ToListAsync();

            return Ok(PCIEGenerations);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            PCIEGeneration? PCIEGeneration = await _context.PCIEGeneration.FirstOrDefaultAsync(PCIEGeneration => PCIEGeneration.UUID == uuid);

            if (PCIEGeneration == null) return NotFound();

            var details = new DTO.Details(PCIEGeneration);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit PCIEGenerationEdits)
        {
            IReadOnlyList<string> errors = PCIEGenerationEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            PCIEGeneration? PCIEGeneration = await _context.PCIEGeneration.FirstOrDefaultAsync(x => x.UUID == PCIEGenerationEdits.UUID);

            if (PCIEGeneration == null) return NotFound();

            PCIEGeneration.Edit(PCIEGeneration, PCIEGenerationEdits);

            await _context.SaveChangesAsync();

            return NoContent();
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
