using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.ChassisUSBPort
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class ChassisUSBPortController : ControllerBase
    {
        private readonly CCContext _context;

        public ChassisUSBPortController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisUSBPort)
        {
            IReadOnlyList<string> errors = createChassisUSBPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool existing = await _context.ChassisUSBPort.AnyAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.USBPortUUID == createChassisUSBPort.USBPortUUID
                && x.ChassisZoneUUID == createChassisUSBPort.ChassisZoneUUID
            );

            if (existing) return Conflict();

            bool chassisExists = await _context.Chassis.AnyAsync(x => x.UUID == chassisUUID);

            if (chassisExists == false) return NotFound();

            bool radiatorSizeExists = await _context.RadiatorSize.AnyAsync(x => x.UUID == createChassisUSBPort.USBPortUUID);

            if (radiatorSizeExists == false) return NotFound();

            bool chassisZoneExists = await _context.ChassisZone.AnyAsync(x => x.UUID == createChassisUSBPort.ChassisZoneUUID);

            if (chassisZoneExists == false) return NotFound();

            ChassisUSBPort ChassisUSBPort = new(chassisUUID, createChassisUSBPort);

            _context.ChassisUSBPort.Add(ChassisUSBPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisUSBPorts = new();
                
            IAsyncEnumerable<ChassisUSBPort> query = _context.ChassisUSBPort
                .Include(x => x.USBPort)
                .Include(x => x.ChassisZone)
                .Where(x => x.ChassisUUID == chassisUUID)
                .AsAsyncEnumerable();

            await foreach (ChassisUSBPort chassisUSBPort in query)
            {
                ChassisUSBPorts.Add(new DTO.Details(chassisUSBPort));
            }

            return Ok(ChassisUSBPorts);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid chassisUUID, DTO.Edit editChassisUSBPort)
        {
            IReadOnlyList<string> errors = editChassisUSBPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisUSBPort? chassisUSBPort = await _context.ChassisUSBPort.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.USBPortUUID == editChassisUSBPort.USBPortUUID
                && x.ChassisZoneUUID == editChassisUSBPort.ChassisZoneUUID
            );

            if (chassisUSBPort == null) return NotFound();

            ChassisUSBPort.Edit(chassisUSBPort, editChassisUSBPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid usbPortUUID, Guid chassisZoneUUID)
        {
            ChassisUSBPort? chassisUSBPort = await _context.ChassisUSBPort.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.USBPortUUID == usbPortUUID
                && x.ChassisZoneUUID == chassisZoneUUID
            );

            if (chassisUSBPort == null) return NotFound();

            _context.ChassisUSBPort.Remove(chassisUSBPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
