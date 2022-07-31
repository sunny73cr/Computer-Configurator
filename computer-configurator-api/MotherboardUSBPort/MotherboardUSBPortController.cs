using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardUSBPort
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class MotherboardUSBPortController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardUSBPortController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid motherboardUUID, DTO.Create createMotherboardUSBPort)
        {
            IReadOnlyList<string> errors = createMotherboardUSBPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool motherboardExists = await _context.Motherboard.AnyAsync(x => x.UUID == motherboardUUID);

            if (motherboardExists == false) return NotFound();

            bool usbPortExists = await _context.USBPort.AnyAsync(x => x.UUID == createMotherboardUSBPort.USBPortUUID);

            if (usbPortExists == false) return NotFound();

            bool duplicate = await _context.MotherboardUSBPort.AnyAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.USBPortUUID == createMotherboardUSBPort.USBPortUUID
            );

            if (duplicate) return Conflict();

            MotherboardUSBPort MotherboardUSBPort = new(motherboardUUID, createMotherboardUSBPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll(Guid motherboardUUID)
        {
            HashSet<DTO.Details> MotherboardUSBPortDetails = new();

            IAsyncEnumerable<MotherboardUSBPort> query = _context.MotherboardUSBPort
                .Include(x => x.USBPort)
                .Where(x => x.MotherboardUUID == motherboardUUID)
                .AsAsyncEnumerable();

            await foreach (MotherboardUSBPort MotherboardUSBPort in query)
            {
                MotherboardUSBPortDetails.Add(new DTO.Details(MotherboardUSBPort));
            }

            return Ok(MotherboardUSBPortDetails);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid motherboardUUID, Guid MotherboardUSBPortUUID)
        {
            MotherboardUSBPort? MotherboardUSBPort = await _context.MotherboardUSBPort
                .Include(x => x.USBPort)
                .FirstOrDefaultAsync(
                    x => x.MotherboardUUID == motherboardUUID
                    && x.USBPortUUID == MotherboardUSBPortUUID
                );

            if (MotherboardUSBPort == null) return NotFound();

            DTO.Details MotherboardUSBPortDetails = new(MotherboardUSBPort);

            return Ok(MotherboardUSBPortDetails);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid motherboardUUID, DTO.Edit editMotherboardUSBPort)
        {
            IReadOnlyList<string> errors = editMotherboardUSBPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardUSBPort? MotherboardUSBPort = await _context.MotherboardUSBPort.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.USBPortUUID == editMotherboardUSBPort.USBPortUUID
            );

            if (MotherboardUSBPort == null) return NotFound();

            MotherboardUSBPort.Edit(MotherboardUSBPort, editMotherboardUSBPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid motherboardUUID, Guid MotherboardUSBPortUUID)
        {
            MotherboardUSBPort? MotherboardUSBPort = await _context.MotherboardUSBPort.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.USBPortUUID == MotherboardUSBPortUUID
            );

            if (MotherboardUSBPort == null) return NotFound();

            _context.MotherboardUSBPort.Remove(MotherboardUSBPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

