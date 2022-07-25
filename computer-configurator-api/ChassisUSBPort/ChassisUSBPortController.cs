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

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisUSBPorts = await _context.ChassisUSBPort
                .Include(x => x.USBPort)
                .Include(x => x.ChassisZone)
                .Where(x => x.ChassisUUID == chassisUUID)
                .Select(ChassisUSBPort => new DTO.Details(ChassisUSBPort))
                .ToListAsync();

            return Ok(ChassisUSBPorts);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisUSBPort)
        {
            IReadOnlyList<string> errors = createChassisUSBPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisUSBPort? existing = await _context.ChassisUSBPort.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.USBPortUUID == createChassisUSBPort.USBPortUUID
                && x.ChassisZoneUUID == createChassisUSBPort.ChassisZoneUUID
            );

            if (existing != null) return Conflict();

            Chassis.Chassis? chassis = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == chassisUUID);

            if (chassis == null) return NotFound();

            RadiatorSize.RadiatorSize? radiatorSize = await _context.RadiatorSize.FirstOrDefaultAsync(x => x.UUID == createChassisUSBPort.USBPortUUID);

            if (radiatorSize == null) return NotFound();

            ChassisZone.ChassisZone? chassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == createChassisUSBPort.ChassisZoneUUID);

            if (chassisZone == null) return NotFound();

            ChassisUSBPort ChassisUSBPort = new(chassisUUID, createChassisUSBPort);

            _context.ChassisUSBPort.Add(ChassisUSBPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid radiatorSizeUUID, Guid chassisZoneUUID)
        {
            ChassisUSBPort? existing = await _context.ChassisUSBPort.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.USBPortUUID == radiatorSizeUUID
                && x.ChassisZoneUUID == chassisZoneUUID
            );

            if (existing == null) return NotFound();

            _context.ChassisUSBPort.Remove(existing);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
