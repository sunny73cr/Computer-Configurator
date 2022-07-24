using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.NVMEFormFactor
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
    public class NVMEFormFactorController : ControllerBase
    {
        private readonly CCContext _context;

        public NVMEFormFactorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createNVMEFormFactor)
        {
            var errors = createNVMEFormFactor.Validate();

            if (errors.Any()) return BadRequest(errors);

            NVMEFormFactor? existing = await _context.NVMEFormFactor.FirstOrDefaultAsync(x => x.UUID == createNVMEFormFactor.UUID);

            if (existing != null) return Conflict();

            NVMEFormFactor NVMEFormFactor = new(createNVMEFormFactor);

            _context.NVMEFormFactor.Add(NVMEFormFactor);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> NVMEFormFactors = await _context.NVMEFormFactor
                .Select(nvmeFormFactor => new DTO.Details(nvmeFormFactor))
                .ToListAsync();

            return Ok(NVMEFormFactors);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            NVMEFormFactor? NVMEFormFactor = await _context.NVMEFormFactor.FirstOrDefaultAsync(NVMEFormFactor => NVMEFormFactor.UUID == uuid);

            if (NVMEFormFactor == null) return NotFound();

            var details = new DTO.Details(NVMEFormFactor);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit NVMEFormFactorEdits)
        {
            IReadOnlyList<string> errors = NVMEFormFactorEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            NVMEFormFactor? NVMEFormFactor = await _context.NVMEFormFactor.FirstOrDefaultAsync(x => x.UUID == NVMEFormFactorEdits.UUID);

            if (NVMEFormFactor == null) return NotFound();

            NVMEFormFactor.Edit(NVMEFormFactor, NVMEFormFactorEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            NVMEFormFactor? NVMEFormFactor = await _context.NVMEFormFactor.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (NVMEFormFactor == null) return NotFound();

            _context.NVMEFormFactor.Remove(NVMEFormFactor);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
