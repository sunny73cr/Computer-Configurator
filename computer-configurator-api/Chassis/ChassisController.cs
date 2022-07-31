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

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createChassis.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createChassis)) return Conflict();

            foreach (ChassisAudioPort.DTO.Create createChassisAudioPort in createChassis.AudioPorts)
            {
                bool audioPortExists = await _context.AudioPort.AnyAsync(x => x.UUID == createChassisAudioPort.AudioPortUUID);

                if (audioPortExists == false) return NotFound();

                bool chassisZoneExists = await _context.ChassisZone.AnyAsync(x => x.UUID == createChassisAudioPort.ChassisZoneUUID);

                if (chassisZoneExists == false) return NotFound();
            }

            foreach (ChassisFanSupport.DTO.Create createChassisFanSupport in createChassis.FanSupport)
            {
                bool fanDiameterExists = await _context.FanDiameter.AnyAsync(x => x.UUID == createChassisFanSupport.FanDiameterUUID);

                if (fanDiameterExists == false) return NotFound();

                bool chassisZoneExists = await _context.ChassisZone.AnyAsync(x => x.UUID == createChassisFanSupport.ChassisZoneUUID);

                if (chassisZoneExists == false) return NotFound();
            }

            foreach (ChassisFilterSupport.DTO.Create createChassisFilterSupport in createChassis.FilterSupport)
            {
                bool chassisZoneExists = await _context.ChassisZone.AnyAsync(x => x.UUID == createChassisFilterSupport.ChassisZoneUUID);

                if (chassisZoneExists == false) return NotFound();
            }

            foreach (ChassisMotherboardFormFactorSupport.DTO.Create createChassisMotherboardFormFactorSupport in createChassis.MotherboardFormFactorSupport)
            {
                bool motherboardFormFactorExists = await _context.MotherboardFormFactor.AnyAsync(x => x.UUID == createChassisMotherboardFormFactorSupport.MotherboardFormFactorUUID);

                if (motherboardFormFactorExists == false) return NotFound();
            }

            foreach (ChassisPowerSupplyFormFactorSupport.DTO.Create createChassisPowerSupplyFormFactorSupport in createChassis.PowerSupplyFormFactorSupport)
            {
                bool powerSupplyFormFactorExists = await _context.PowerSupplyFormFactor.AnyAsync(x => x.UUID == createChassisPowerSupplyFormFactorSupport.PowerSupplyFormFactorUUID);

                if (powerSupplyFormFactorExists == false) return NotFound();
            }

            foreach (ChassisRadiatorSupport.DTO.Create createChassisRadiatorSupport in createChassis.RadiatorSupport)
            {
                bool radiatorSize = await _context.RadiatorSize.AnyAsync(x => x.UUID == createChassisRadiatorSupport.RadiatorSizeUUID);

                if (radiatorSize == false) return NotFound();

                bool chassisZoneExists = await _context.ChassisZone.AnyAsync(x => x.UUID == createChassisRadiatorSupport.ChassisZoneUUID);

                if (chassisZoneExists == false) return NotFound();
            }

            foreach (ChassisUSBPort.DTO.Create createChassisUSBPort in createChassis.USBPorts)
            {
                bool usbPort = await _context.USBPort.AnyAsync(x => x.UUID == createChassisUSBPort.USBPortUUID);

                if (usbPort == false) return NotFound();

                bool chassisZoneExists = await _context.ChassisZone.AnyAsync(x => x.UUID == createChassisUSBPort.ChassisZoneUUID);

                if (chassisZoneExists == false) return NotFound();
            }

            Chassis Chassis = new(createChassis);

            _context.Chassis.Add(Chassis);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> ChassisDetails = new();

            IAsyncEnumerable<Chassis> query = _context.Chassis
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.AudioPorts)
                .Include(x => x.FanSupport)
                .Include(x => x.FilterSupport)
                .Include(x => x.MotherboardFormFactorSupport)
                .Include(x => x.PowerSupplyFormFactorSupport)
                .Include(x => x.RadiatorSupport)
                .Include(x => x.USBPorts)
                .AsAsyncEnumerable();

            await foreach (Chassis chassis in query)
            {
                ChassisDetails.Add(new DTO.Details(chassis));
            }

            return Ok(ChassisDetails);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            Chassis? Chassis = await _context.Chassis
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.AudioPorts)
                .Include(x => x.FanSupport)
                .Include(x => x.FilterSupport)
                .Include(x => x.MotherboardFormFactorSupport)
                .Include(x => x.PowerSupplyFormFactorSupport)
                .Include(x => x.RadiatorSupport)
                .Include(x => x.USBPorts)
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

            if (Chassis.ManufacturerUUID != ChassisEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == ChassisEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (Chassis.Model.ToLower() != ChassisEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, ChassisEdits);

                    if (duplicate) return Conflict();
                }
            }

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
