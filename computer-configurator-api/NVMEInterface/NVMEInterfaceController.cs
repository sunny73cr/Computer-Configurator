using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.NVMEInterface
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
    public class NVMEInterfaceController : ControllerBase
    {
        private readonly CCContext _context;

        public NVMEInterfaceController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createNVMEInterface)
        {
            var errors = createNVMEInterface.Validate();

            if (errors.Any()) return BadRequest(errors);

            NVMEInterface? existing = await _context.NVMEInterface.FirstOrDefaultAsync(x => x.UUID == createNVMEInterface.UUID);

            if (existing != null) return Conflict();

            NVMEInterface NVMEInterface = new(createNVMEInterface);

            _context.NVMEInterface.Add(NVMEInterface);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> NVMEInterfaces = await _context.NVMEInterface
                .Select(nvmeInterface => new DTO.Details(nvmeInterface))
                .ToListAsync();

            return Ok(NVMEInterfaces);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            NVMEInterface? NVMEInterface = await _context.NVMEInterface.FirstOrDefaultAsync(NVMEInterface => NVMEInterface.UUID == uuid);

            if (NVMEInterface == null) return NotFound();

            var details = new DTO.Details(NVMEInterface);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit NVMEInterfaceEdits)
        {
            IReadOnlyList<string> errors = NVMEInterfaceEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            NVMEInterface? NVMEInterface = await _context.NVMEInterface.FirstOrDefaultAsync(x => x.UUID == NVMEInterfaceEdits.UUID);

            if (NVMEInterface == null) return NotFound();

            NVMEInterface.Edit(NVMEInterface, NVMEInterfaceEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            NVMEInterface? NVMEInterface = await _context.NVMEInterface.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (NVMEInterface == null) return NotFound();

            _context.NVMEInterface.Remove(NVMEInterface);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
