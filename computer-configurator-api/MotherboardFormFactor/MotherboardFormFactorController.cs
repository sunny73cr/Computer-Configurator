using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardFormFactor
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class MotherboardFormFactorController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardFormFactorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createMotherboardFormFactor)
        {
            var errors = createMotherboardFormFactor.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardFormFactor? existing = await _context.MotherboardFormFactor.FirstOrDefaultAsync(x => x.UUID == createMotherboardFormFactor.UUID);

            if (existing != null) return Conflict();

            MotherboardFormFactor MotherboardFormFactor = new(createMotherboardFormFactor);

            _context.MotherboardFormFactor.Add(MotherboardFormFactor);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll()
        {
            List<DTO.Details> MotherboardFormFactors = await _context.MotherboardFormFactor
                .Select(motherboardFormFactor => new DTO.Details(motherboardFormFactor))
                .ToListAsync();

            return Ok(MotherboardFormFactors);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            MotherboardFormFactor? MotherboardFormFactor = await _context.MotherboardFormFactor.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (MotherboardFormFactor == null) return NotFound();

            _context.MotherboardFormFactor.Remove(MotherboardFormFactor);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
