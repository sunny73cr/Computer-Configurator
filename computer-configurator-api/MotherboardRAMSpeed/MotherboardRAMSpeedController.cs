using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardRAMSpeed
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class MotherboardRAMSpeedController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardRAMSpeedController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid motherboardUUID, DTO.Create createMotherboardRAMSpeed)
        {
            IReadOnlyList<string> errors = createMotherboardRAMSpeed.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool motherboardExists = await _context.Motherboard.AnyAsync(x => x.UUID == motherboardUUID);

            if (motherboardExists == false) return NotFound();

            bool ramSpeedExists = await _context.RAMSpeed.AnyAsync(x => x.UUID == createMotherboardRAMSpeed.RAMSpeedUUID);

            if (ramSpeedExists == false) return NotFound();

            bool duplicate = await _context.MotherboardRAMSpeed.AnyAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.RAMSpeedUUID == createMotherboardRAMSpeed.RAMSpeedUUID
            );

            if (duplicate) return Conflict();

            MotherboardRAMSpeed MotherboardRAMSpeed = new(motherboardUUID, createMotherboardRAMSpeed);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll(Guid motherboardUUID)
        {
            HashSet<DTO.Details> MotherboardRAMSpeedDetails = new();

            IAsyncEnumerable<MotherboardRAMSpeed> query = _context.MotherboardRAMSpeed
                .Include(x => x.RAMSpeed)
                .Where(x => x.MotherboardUUID == motherboardUUID)
                .AsAsyncEnumerable();

            await foreach (MotherboardRAMSpeed MotherboardRAMSpeed in query)
            {
                MotherboardRAMSpeedDetails.Add(new DTO.Details(MotherboardRAMSpeed));
            }

            return Ok(MotherboardRAMSpeedDetails);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid motherboardUUID, Guid MotherboardRAMSpeedUUID)
        {
            MotherboardRAMSpeed? MotherboardRAMSpeed = await _context.MotherboardRAMSpeed
                .Include(x => x.RAMSpeed)
                .FirstOrDefaultAsync(
                    x => x.MotherboardUUID == motherboardUUID
                    && x.RAMSpeedUUID == MotherboardRAMSpeedUUID
                );

            if (MotherboardRAMSpeed == null) return NotFound();

            DTO.Details MotherboardRAMSpeedDetails = new(MotherboardRAMSpeed);

            return Ok(MotherboardRAMSpeedDetails);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid motherboardUUID, DTO.Edit editMotherboardRAMSpeed)
        {
            IReadOnlyList<string> errors = editMotherboardRAMSpeed.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardRAMSpeed? MotherboardRAMSpeed = await _context.MotherboardRAMSpeed.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.RAMSpeedUUID == editMotherboardRAMSpeed.RAMSocketUUID
            );

            if (MotherboardRAMSpeed == null) return NotFound();

            MotherboardRAMSpeed.Edit(MotherboardRAMSpeed, editMotherboardRAMSpeed);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid motherboardUUID, Guid MotherboardRAMSpeedUUID)
        {
            MotherboardRAMSpeed? MotherboardRAMSpeed = await _context.MotherboardRAMSpeed.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.RAMSpeedUUID == MotherboardRAMSpeedUUID
            );

            if (MotherboardRAMSpeed == null) return NotFound();

            _context.MotherboardRAMSpeed.Remove(MotherboardRAMSpeed);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

