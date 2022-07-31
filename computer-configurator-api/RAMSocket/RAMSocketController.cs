using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.RAMSocket
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class RAMSocketController : ControllerBase
    {
        private readonly CCContext _context;

        public RAMSocketController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createRAMSocket)
        {
            var errors = createRAMSocket.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool duplicate = await _context.RAMSocket.AnyAsync(x => x.Version == createRAMSocket.Version);

            if (duplicate) return Conflict();

            RAMSocket RAMSocket = new(createRAMSocket);

            _context.RAMSocket.Add(RAMSocket);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> RAMSockets = new();

            IAsyncEnumerable<RAMSocket> query = _context.RAMSocket
               .AsAsyncEnumerable();

            await foreach (RAMSocket ramSocket in query)
            {
                RAMSockets.Add(new DTO.Details(ramSocket));
            }

            return Ok(RAMSockets);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            RAMSocket? RAMSocket = await _context.RAMSocket.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (RAMSocket == null) return NotFound();

            _context.RAMSocket.Remove(RAMSocket);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
