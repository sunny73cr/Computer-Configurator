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

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisAudioPort)
        {
            IReadOnlyList<string> errors = createChassisAudioPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool existing = await _context.ChassisAudioPort.AnyAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.AudioPortUUID == createChassisAudioPort.AudioPortUUID
                && x.ChassisZoneUUID == createChassisAudioPort.ChassisZoneUUID
            );

            if (existing) return Conflict();

            bool chassisExists = await _context.Chassis.AnyAsync(x => x.UUID == chassisUUID);

            if (chassisExists == false) return NotFound();

            bool chassisZoneExists = await _context.ChassisZone.AnyAsync(x => x.UUID == createChassisAudioPort.ChassisZoneUUID);

            if (chassisZoneExists == false) return NotFound();

            bool audioPortExists = await _context.AudioPort.AnyAsync(x => x.UUID == createChassisAudioPort.AudioPortUUID);

            if (audioPortExists == false) return NotFound();

            ChassisAudioPort chassisAudioPort = new(chassisUUID, createChassisAudioPort);

            _context.ChassisAudioPort.Add(chassisAudioPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisAudioPorts = new();

            IAsyncEnumerable<ChassisAudioPort> query = _context.ChassisAudioPort
                .Include(x => x.AudioPort)
                .Include(x => x.ChassisZone)
                .Where(x => x.ChassisUUID == chassisUUID)
                .AsAsyncEnumerable();

            await foreach (ChassisAudioPort chassisAudioPort in query)
            {
                ChassisAudioPorts.Add(new DTO.Details(chassisAudioPort));
            }

            return Ok(ChassisAudioPorts);
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
