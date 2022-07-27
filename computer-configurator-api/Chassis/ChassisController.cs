using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.Chassis
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class ChassisController : ControllerBase
    {
        private readonly CCContext _context;

        public ChassisController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createChassis)
        {
            var errors = createChassis.Validate();

            if (errors.Any()) return BadRequest(errors);

            Chassis? existing = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == createChassis.UUID);

            if (existing != null) return Conflict();

            foreach (ChassisAudioPort.DTO.Create createChassisAudioPort in createChassis.AudioPorts)
            {
                AudioPort.AudioPort? audioPort = await _context.AudioPort.FirstOrDefaultAsync(x => x.UUID == createChassisAudioPort.AudioPortUUID);

                if (audioPort == null) return NotFound();

                ChassisZone.ChassisZone? chassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == createChassisAudioPort.ChassisZoneUUID);

                if (chassisZone == null) return NotFound();
            }

            foreach (ChassisFanSupport.DTO.Create createChassisFanSupport in createChassis.FanSupport)
            {
                FanDiameter.FanDiameter? fanDiameter = await _context.FanDiameter.FirstOrDefaultAsync(x => x.UUID == createChassisFanSupport.FanDiameterUUID);

                if (fanDiameter == null) return NotFound();

                ChassisZone.ChassisZone? chassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == createChassisFanSupport.ChassisZoneUUID);

                if (chassisZone == null) return NotFound();
            }

            foreach (ChassisFilterSupport.DTO.Create createChassisFilterSupport in createChassis.FilterSupport)
            {
                ChassisZone.ChassisZone? chassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == createChassisFilterSupport.ChassisZoneUUID);

                if (chassisZone == null) return NotFound();
            }

            foreach (ChassisMotherboardFormFactorSupport.DTO.Create createChassisMotherboardFormFactorSupport in createChassis.MotherboardFormFactorSupport)
            {
                MotherboardFormFactor.MotherboardFormFactor? motherboardFormFactor = await _context.MotherboardFormFactor.FirstOrDefaultAsync(x => x.UUID == createChassisMotherboardFormFactorSupport.MotherboardFormFactorUUID);

                if (motherboardFormFactor == null) return NotFound();
            }

            foreach (ChassisPowerSupplyFormFactorSupport.DTO.Create createChassisPowerSupplyFormFactorSupport in createChassis.PowerSupplyFormFactorSupport)
            {
                PowerSupplyFormFactor.PowerSupplyFormFactor? powerSupplyFormFactor = await _context.PowerSupplyFormFactor.FirstOrDefaultAsync(x => x.UUID == createChassisPowerSupplyFormFactorSupport.PowerSupplyFormFactorUUID);

                if (powerSupplyFormFactor == null) return NotFound();
            }

            foreach (ChassisRadiatorSupport.DTO.Create createChassisRadiatorSupport in createChassis.RadiatorSupport)
            {
                RadiatorSize.RadiatorSize? radiatorSize = await _context.RadiatorSize.FirstOrDefaultAsync(x => x.UUID == createChassisRadiatorSupport.RadiatorSizeUUID);

                if (radiatorSize == null) return NotFound();

                ChassisZone.ChassisZone ? chassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == createChassisRadiatorSupport.ChassisZoneUUID);

                if (chassisZone == null) return NotFound();
            }

            foreach (ChassisUSBPort.DTO.Create createChassisUSBPort in createChassis.USBPorts)
            {
                USBPort.USBPort? usbPort = await _context.USBPort.FirstOrDefaultAsync(x => x.UUID == createChassisUSBPort.USBPortUUID);

                if (usbPort == null) return NotFound();

                ChassisZone.ChassisZone? chassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == createChassisUSBPort.ChassisZoneUUID);

                if (chassisZone == null) return NotFound();
            }

            Chassis Chassis = new(createChassis);

            _context.Chassis.Add(Chassis);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            Chassis? Chassis = await _context.Chassis
                .Include(Chassis => Chassis.Part)
                .ThenInclude(part => part.Manufacturer)
                .FirstOrDefaultAsync(Chassis => Chassis.UUID == uuid);

            if (Chassis == null) return NotFound();

            var details = new DTO.Details(Chassis);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit ChassisEdits)
        {
            IReadOnlyList<string> errors = ChassisEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            Chassis? Chassis = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == ChassisEdits.UUID);

            if (Chassis == null) return NotFound();

            Chassis.Edit(Chassis, ChassisEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            Chassis? placeholder = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (placeholder == null) return NotFound();

            _context.Chassis.Remove(placeholder);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
