using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.NVMEFormFactor
{
    [ApiController]
    [Route("/[controller]/[action]/")]
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

            bool duplicate = await _context.NVMEFormFactor.AnyAsync(x => x.FormFactor == createNVMEFormFactor.FormFactor);

            if (duplicate) return Conflict();

            NVMEFormFactor NVMEFormFactor = new(createNVMEFormFactor);

            _context.NVMEFormFactor.Add(NVMEFormFactor);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> NVMEFormFactors = new();

            IAsyncEnumerable<NVMEFormFactor> query = _context.NVMEFormFactor
                .AsAsyncEnumerable();

            await foreach (NVMEFormFactor nvmeFormFactor in query)
            {
                NVMEFormFactors.Add(new DTO.Details(nvmeFormFactor));
            }

            return Ok(NVMEFormFactors);
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
