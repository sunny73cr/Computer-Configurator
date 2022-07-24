using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MountedStorageFormFactor
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
    public class MountedStorageFormFactorController : ControllerBase
    {
        private readonly CCContext _context;

        public MountedStorageFormFactorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createMountedStorageFormFactor)
        {
            var errors = createMountedStorageFormFactor.Validate();

            if (errors.Any()) return BadRequest(errors);

            MountedStorageFormFactor? existing = await _context.MountedStorageFormFactor.FirstOrDefaultAsync(x => x.UUID == createMountedStorageFormFactor.UUID);

            if (existing != null) return Conflict();

            MountedStorageFormFactor MountedStorageFormFactor = new(createMountedStorageFormFactor);

            _context.MountedStorageFormFactor.Add(MountedStorageFormFactor);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> MountedStorageFormFactors = await _context.MountedStorageFormFactor
                .Select(mountedStorageFormFactor => new DTO.Details(mountedStorageFormFactor))
                .ToListAsync();

            return Ok(MountedStorageFormFactors);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            MountedStorageFormFactor? MountedStorageFormFactor = await _context.MountedStorageFormFactor.FirstOrDefaultAsync(MountedStorageFormFactor => MountedStorageFormFactor.UUID == uuid);

            if (MountedStorageFormFactor == null) return NotFound();

            var details = new DTO.Details(MountedStorageFormFactor);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit MountedStorageFormFactorEdits)
        {
            IReadOnlyList<string> errors = MountedStorageFormFactorEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            MountedStorageFormFactor? MountedStorageFormFactor = await _context.MountedStorageFormFactor.FirstOrDefaultAsync(x => x.UUID == MountedStorageFormFactorEdits.UUID);

            if (MountedStorageFormFactor == null) return NotFound();

            MountedStorageFormFactor.Edit(MountedStorageFormFactor, MountedStorageFormFactorEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            MountedStorageFormFactor? MountedStorageFormFactor = await _context.MountedStorageFormFactor.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (MountedStorageFormFactor == null) return NotFound();

            _context.MountedStorageFormFactor.Remove(MountedStorageFormFactor);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
