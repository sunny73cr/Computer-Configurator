using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.ChassisMotherboardFormFactorSupport
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class ChassisMotherboardFormFactorSupportController : ControllerBase
    {
        private readonly CCContext _context;

        public ChassisMotherboardFormFactorSupportController(CCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisMotherboardFormFactorSupports = await _context.ChassisMotherboardFormFactorSupport
                .Include(x => x.MotherboardFormFactor)
                .Where(x => x.ChassisUUID == chassisUUID)
                .Select(ChassisMotherboardFormFactorSupport => new DTO.Details(ChassisMotherboardFormFactorSupport))
                .ToListAsync();

            return Ok(ChassisMotherboardFormFactorSupports);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisMotherboardFormFactorSupport)
        {
            IReadOnlyList<string> errors = createChassisMotherboardFormFactorSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            ChassisMotherboardFormFactorSupport? existing = await _context.ChassisMotherboardFormFactorSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.MotherboardFormFactorUUID == createChassisMotherboardFormFactorSupport.MotherboardFormFactorUUID
            );

            if (existing != null) return Conflict();

            Chassis.Chassis? chassis = await _context.Chassis.FirstOrDefaultAsync(x => x.UUID == chassisUUID);

            if (chassis == null) return NotFound();

            MotherboardFormFactor.MotherboardFormFactor? motherboardFormFactorUUID = await _context.MotherboardFormFactor.FirstOrDefaultAsync(x => x.UUID == createChassisMotherboardFormFactorSupport.MotherboardFormFactorUUID);

            if (motherboardFormFactorUUID == null) return NotFound();

            ChassisMotherboardFormFactorSupport ChassisMotherboardFormFactorSupport = new(chassisUUID, createChassisMotherboardFormFactorSupport);

            _context.ChassisMotherboardFormFactorSupport.Add(ChassisMotherboardFormFactorSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid motherboardFormFactorUUID)
        {
            ChassisMotherboardFormFactorSupport? existing = await _context.ChassisMotherboardFormFactorSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.MotherboardFormFactorUUID == motherboardFormFactorUUID
            );

            if (existing == null) return NotFound();

            _context.ChassisMotherboardFormFactorSupport.Remove(existing);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
