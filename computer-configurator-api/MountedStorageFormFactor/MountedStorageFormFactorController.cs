using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MountedStorageFormFactor
{
    [ApiController]
    [Route("/[controller]/[action]/")]
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

            bool duplicate = await _context.MountedStorageFormFactor.AnyAsync(x => x.Size == createMountedStorageFormFactor.Size);

            if (duplicate) return Conflict();

            MountedStorageFormFactor MountedStorageFormFactor = new(createMountedStorageFormFactor);

            _context.MountedStorageFormFactor.Add(MountedStorageFormFactor);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> MountedStorageFormFactors = new();

            IAsyncEnumerable<MountedStorageFormFactor> query = _context.MountedStorageFormFactor
                .AsAsyncEnumerable();

            await foreach (MountedStorageFormFactor mountedStorageFormFactor in query)
            {
                MountedStorageFormFactors.Add(new DTO.Details(mountedStorageFormFactor));
            }

            return Ok(MountedStorageFormFactors);
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
