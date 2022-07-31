using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardFanHeader
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class MotherboardFanHeaderController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardFanHeaderController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid motherboardUUID, DTO.Create createMotherboardFanHeader)
        {
            IReadOnlyList<string> errors = createMotherboardFanHeader.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool motherboardExists = await _context.Motherboard.AnyAsync(x => x.UUID == motherboardUUID);

            if (motherboardExists == false) return NotFound();

            bool fanHeaderExists = await _context.FanHeader.AnyAsync(x => x.UUID == createMotherboardFanHeader.FanHeaderUUID);

            if (fanHeaderExists == false) return NotFound();

            bool duplicate = await _context.MotherboardFanHeader.AnyAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.FanHeaderUUID == createMotherboardFanHeader.FanHeaderUUID
            );

            if (duplicate) return Conflict();

            MotherboardFanHeader MotherboardFanHeader = new(motherboardUUID, createMotherboardFanHeader);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll(Guid motherboardUUID)
        {
            HashSet<DTO.Details> MotherboardFanHeaderDetails = new();

            IAsyncEnumerable<MotherboardFanHeader> query = _context.MotherboardFanHeader
                .Include(x => x.FanHeader)
                .Where(x => x.MotherboardUUID == motherboardUUID)
                .AsAsyncEnumerable();

            await foreach (MotherboardFanHeader MotherboardFanHeader in query)
            {
                MotherboardFanHeaderDetails.Add(new DTO.Details(MotherboardFanHeader));
            }

            return Ok(MotherboardFanHeaderDetails);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid motherboardUUID, Guid MotherboardFanHeaderUUID)
        {
            MotherboardFanHeader? MotherboardFanHeader = await _context.MotherboardFanHeader
                .Include(x => x.FanHeader)
                .FirstOrDefaultAsync(
                    x => x.MotherboardUUID == motherboardUUID
                    && x.FanHeaderUUID == MotherboardFanHeaderUUID
                );

            if (MotherboardFanHeader == null) return NotFound();

            DTO.Details MotherboardFanHeaderDetails = new(MotherboardFanHeader);

            return Ok(MotherboardFanHeaderDetails);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid motherboardUUID, DTO.Edit editMotherboardFanHeader)
        {
            IReadOnlyList<string> errors = editMotherboardFanHeader.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardFanHeader? MotherboardFanHeader = await _context.MotherboardFanHeader.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.FanHeaderUUID == editMotherboardFanHeader.FanHeaderUUID
            );

            if (MotherboardFanHeader == null) return NotFound();

            MotherboardFanHeader.Edit(MotherboardFanHeader, editMotherboardFanHeader);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid motherboardUUID, Guid MotherboardFanHeaderUUID)
        {
            MotherboardFanHeader? MotherboardFanHeader = await _context.MotherboardFanHeader.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.FanHeaderUUID == MotherboardFanHeaderUUID
            );

            if (MotherboardFanHeader == null) return NotFound();

            _context.MotherboardFanHeader.Remove(MotherboardFanHeader);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

