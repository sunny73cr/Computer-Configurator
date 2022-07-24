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

            RAMSocket? existing = await _context.RAMSocket.FirstOrDefaultAsync(x => x.UUID == createRAMSocket.UUID);

            if (existing != null) return Conflict();

            RAMSocket RAMSocket = new(createRAMSocket);

            _context.RAMSocket.Add(RAMSocket);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> RAMSockets = await _context.RAMSocket
                .Select(ramSocket => new DTO.Details(ramSocket))
                .ToListAsync();

            return Ok(RAMSockets);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            RAMSocket? RAMSocket = await _context.RAMSocket.FirstOrDefaultAsync(RAMSocket => RAMSocket.UUID == uuid);

            if (RAMSocket == null) return NotFound();

            var details = new DTO.Details(RAMSocket);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit RAMSocketEdits)
        {
            IReadOnlyList<string> errors = RAMSocketEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            RAMSocket? RAMSocket = await _context.RAMSocket.FirstOrDefaultAsync(x => x.UUID == RAMSocketEdits.UUID);

            if (RAMSocket == null) return NotFound();

            RAMSocket.Edit(RAMSocket, RAMSocketEdits);

            await _context.SaveChangesAsync();

            return NoContent();
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
