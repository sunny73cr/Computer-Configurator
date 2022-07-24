using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.AudioPort
{
    [ApiController]
    [Route("/[controller]/[action]/{id}")]
    public class AudioPortController : ControllerBase
    {
        private readonly CCContext _context;

        public AudioPortController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createAudioPort)
        {
            var errors = createAudioPort.Validate();

            if (errors.Any()) return BadRequest(errors);

            AudioPort? existing = await _context.AudioPort.FirstOrDefaultAsync(x => x.UUID == createAudioPort.UUID);

            if (existing != null) return Conflict();

            AudioPort AudioPort = new(createAudioPort);

            _context.AudioPort.Add(AudioPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> AudioPorts = await _context.AudioPort
                .Select(audioPort => new DTO.Details(audioPort))
                .ToListAsync();

            return Ok(AudioPorts);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            AudioPort? AudioPort = await _context.AudioPort.FirstOrDefaultAsync(AudioPort => AudioPort.UUID == uuid);

            if (AudioPort == null) return NotFound();

            var details = new DTO.Details(AudioPort);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit AudioPortEdits)
        {
            IReadOnlyList<string> errors = AudioPortEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            AudioPort? AudioPort = await _context.AudioPort.FirstOrDefaultAsync(x => x.UUID == AudioPortEdits.UUID);

            if (AudioPort == null) return NotFound();

            AudioPort.Edit(AudioPort, AudioPortEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            AudioPort? AudioPort = await _context.AudioPort.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (AudioPort == null) return NotFound();

            _context.AudioPort.Remove(AudioPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
