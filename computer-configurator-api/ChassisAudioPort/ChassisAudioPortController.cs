using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.ChassisAudioPort
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class ChassisAudioPortController : ControllerBase
    {
        private readonly CCContext _context;

        public ChassisAudioPortController(CCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisAudioPorts = await _context.ChassisAudioPort
                .Include(x => x.AudioPort)
                .Include(x => x.ChassisZone)
                .Where(x => x.ChassisUUID == chassisUUID)
                .Select(chassisAudioPort => new DTO.Details(chassisAudioPort))
                .ToListAsync();

            return Ok(ChassisAudioPorts);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisAudioPort)
        {
            IReadOnlyList<string> errors = createChassisAudioPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisAudioPort? existing = await _context.ChassisAudioPort.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.AudioPortUUID == createChassisAudioPort.AudioPortUUID
                && x.ChassisZoneUUID == createChassisAudioPort.ChassisZoneUUID
            );

            if (existing != null) return Conflict();

            Chassis.Chassis? chassis = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == chassisUUID);

            if (chassis == null) return NotFound();

            ChassisZone.ChassisZone? chassisZone = await _context.ChassisZone.FirstOrDefaultAsync(x => x.UUID == createChassisAudioPort.ChassisZoneUUID);

            if (chassisZone == null) return NotFound();

            AudioPort.AudioPort? audioPort = await _context.AudioPort.FirstOrDefaultAsync(x => x.UUID == createChassisAudioPort.AudioPortUUID);

            if (audioPort == null) return NotFound();

            ChassisAudioPort chassisAudioPort = new(chassisUUID, createChassisAudioPort);

            _context.ChassisAudioPort.Add(chassisAudioPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid audioPortUUID, Guid chassisZoneUUID)
        {
            ChassisAudioPort? existing = await _context.ChassisAudioPort.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.AudioPortUUID == audioPortUUID
                && x.ChassisZoneUUID == chassisZoneUUID
            );

            if (existing == null) return NotFound();

            _context.ChassisAudioPort.Remove(existing);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
