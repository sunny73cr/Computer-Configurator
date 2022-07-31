using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardRAMSocket
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class MotherboardRAMSocketController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardRAMSocketController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid motherboardUUID, DTO.Create createMotherboardRAMSocket)
        {
            IReadOnlyList<string> errors = createMotherboardRAMSocket.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool motherboardExists = await _context.Motherboard.AnyAsync(x => x.UUID == motherboardUUID);

            if (motherboardExists == false) return NotFound();

            bool ramSocketExists = await _context.RAMSocket.AnyAsync(x => x.UUID == createMotherboardRAMSocket.RAMSocketUUID);

            if (ramSocketExists == false) return NotFound();

            bool duplicate = await _context.MotherboardRAMSocket.AnyAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.RAMSocketUUID == createMotherboardRAMSocket.RAMSocketUUID
            );

            if (duplicate) return Conflict();

            MotherboardRAMSocket MotherboardRAMSocket = new(motherboardUUID, createMotherboardRAMSocket);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll(Guid motherboardUUID)
        {
            HashSet<DTO.Details> MotherboardRAMSocketDetails = new();

            IAsyncEnumerable<MotherboardRAMSocket> query = _context.MotherboardRAMSocket
                .Include(x => x.RAMSocket)
                .Where(x => x.MotherboardUUID == motherboardUUID)
                .AsAsyncEnumerable();

            await foreach (MotherboardRAMSocket MotherboardRAMSocket in query)
            {
                MotherboardRAMSocketDetails.Add(new DTO.Details(MotherboardRAMSocket));
            }

            return Ok(MotherboardRAMSocketDetails);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid motherboardUUID, Guid MotherboardRAMSocketUUID)
        {
            MotherboardRAMSocket? MotherboardRAMSocket = await _context.MotherboardRAMSocket
                .Include(x => x.RAMSocket)
                .FirstOrDefaultAsync(
                    x => x.MotherboardUUID == motherboardUUID
                    && x.RAMSocketUUID == MotherboardRAMSocketUUID
                );

            if (MotherboardRAMSocket == null) return NotFound();

            DTO.Details MotherboardRAMSocketDetails = new(MotherboardRAMSocket);

            return Ok(MotherboardRAMSocketDetails);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid motherboardUUID, DTO.Edit editMotherboardRAMSocket)
        {
            IReadOnlyList<string> errors = editMotherboardRAMSocket.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardRAMSocket? MotherboardRAMSocket = await _context.MotherboardRAMSocket.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.RAMSocketUUID == editMotherboardRAMSocket.RAMSocketUUID
            );

            if (MotherboardRAMSocket == null) return NotFound();

            MotherboardRAMSocket.Edit(MotherboardRAMSocket, editMotherboardRAMSocket);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid motherboardUUID, Guid MotherboardRAMSocketUUID)
        {
            MotherboardRAMSocket? MotherboardRAMSocket = await _context.MotherboardRAMSocket.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.RAMSocketUUID == MotherboardRAMSocketUUID
            );

            if (MotherboardRAMSocket == null) return NotFound();

            _context.MotherboardRAMSocket.Remove(MotherboardRAMSocket);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

