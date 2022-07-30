using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardEthernetPort
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class MotherboardEthernetPortController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardEthernetPortController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid motherboardUUID, DTO.Create createMotherboardEthernetPort)
        {
            IReadOnlyList<string> errors = createMotherboardEthernetPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool motherboardExists = await _context.Motherboard.AnyAsync(x => x.UUID == motherboardUUID);

            if (motherboardExists == false) return NotFound();

            bool ethernetPortExists = await _context.EthernetPort.AnyAsync(x => x.UUID == createMotherboardEthernetPort.EthernetPortUUID);

            if (ethernetPortExists == false) return NotFound();

            bool duplicate = await _context.MotherboardEthernetPort.AnyAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.EthernetPortUUID == createMotherboardEthernetPort.EthernetPortUUID
            );

            if (duplicate) return Conflict();

            MotherboardEthernetPort MotherboardEthernetPort = new(motherboardUUID, createMotherboardEthernetPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll(Guid motherboardUUID)
        {
            HashSet<DTO.Details> MotherboardEthernetPortDetails = new();

            IAsyncEnumerable<MotherboardEthernetPort> query = _context.MotherboardEthernetPort
                .Include(x => x.EthernetPort)
                .Where(x => x.MotherboardUUID == motherboardUUID)
                .AsAsyncEnumerable();

            await foreach (MotherboardEthernetPort MotherboardEthernetPort in query)
            {
                MotherboardEthernetPortDetails.Add(new DTO.Details(MotherboardEthernetPort));
            }

            return Ok(MotherboardEthernetPortDetails);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid motherboardUUID, Guid MotherboardEthernetPortUUID)
        {
            MotherboardEthernetPort? MotherboardEthernetPort = await _context.MotherboardEthernetPort
                .Include(x => x.EthernetPort)
                .FirstOrDefaultAsync(
                    x => x.MotherboardUUID == motherboardUUID
                    && x.EthernetPortUUID == MotherboardEthernetPortUUID
                );

            if (MotherboardEthernetPort == null) return NotFound();

            DTO.Details MotherboardEthernetPortDetails = new(MotherboardEthernetPort);

            return Ok(MotherboardEthernetPortDetails);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid motherboardUUID, DTO.Edit editMotherboardEthernetPort)
        {
            IReadOnlyList<string> errors = editMotherboardEthernetPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardEthernetPort? MotherboardEthernetPort = await _context.MotherboardEthernetPort.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.EthernetPortUUID == editMotherboardEthernetPort.EthernetPortUUID
            );

            if (MotherboardEthernetPort == null) return NotFound();

            MotherboardEthernetPort.Edit(MotherboardEthernetPort, editMotherboardEthernetPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid motherboardUUID, Guid MotherboardEthernetPortUUID)
        {
            MotherboardEthernetPort? MotherboardEthernetPort = await _context.MotherboardEthernetPort.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.EthernetPortUUID == MotherboardEthernetPortUUID
            );

            if (MotherboardEthernetPort == null) return NotFound();

            _context.MotherboardEthernetPort.Remove(MotherboardEthernetPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
