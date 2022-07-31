using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.NVMEInterface
{
    [ApiController]
    [Route("/[controller]/[action]/")]
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

            bool duplicate = await _context.NVMEInterface.AnyAsync(x => x.Interface == createNVMEInterface.Interface);

            if (duplicate) return Conflict();

            NVMEInterface NVMEInterface = new(createNVMEInterface);

            _context.NVMEInterface.Add(NVMEInterface);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> NVMEInterfaces = new();

            IAsyncEnumerable<NVMEInterface> query = _context.NVMEInterface
                .AsAsyncEnumerable();

            await foreach (NVMEInterface nvmeInterface in query)
            {
                NVMEInterfaces.Add(new DTO.Details(nvmeInterface));
            }

            return Ok(NVMEInterfaces);
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
