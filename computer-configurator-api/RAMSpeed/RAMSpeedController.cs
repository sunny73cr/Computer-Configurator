using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.RAMSpeed
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class RAMSpeedController : ControllerBase
    {
        private readonly CCContext _context;

        public RAMSpeedController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createRAMSpeed)
        {
            var errors = createRAMSpeed.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool duplicate = await _context.RAMSpeed.AnyAsync(x => x.ClockRate == createRAMSpeed.ClockRate);

            if (duplicate) return Conflict();

            RAMSpeed RAMSpeed = new(createRAMSpeed);

            _context.RAMSpeed.Add(RAMSpeed);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> RAMSpeeds = new();

            IAsyncEnumerable<RAMSpeed> query = _context.RAMSpeed
                .AsAsyncEnumerable();

            await foreach (RAMSpeed ramSpeed in query)
            {
                RAMSpeeds.Add(new DTO.Details(ramSpeed));
            }

            return Ok(RAMSpeeds);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            RAMSpeed? RAMSpeed = await _context.RAMSpeed.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (RAMSpeed == null) return NotFound();

            _context.RAMSpeed.Remove(RAMSpeed);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
