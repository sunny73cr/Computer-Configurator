using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.AudioPort
{
    [ApiController]
    [Route("/[controller]/[action]/")]
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

            bool existing = await _context.AudioPort.AnyAsync(x =>
                x.ConnectorSize == createAudioPort.ConnectorSize
                && x.PinCount == createAudioPort.PinCount
            );

            if (existing) return Conflict();

            AudioPort AudioPort = new(createAudioPort);

            _context.AudioPort.Add(AudioPort);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> AudioPorts = new();

            IAsyncEnumerable<AudioPort> query = _context.AudioPort.AsAsyncEnumerable();

            await foreach (AudioPort audioPort in query)
            {
                AudioPorts.Add(new DTO.Details(audioPort));
            }

            return Ok(AudioPorts);
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
