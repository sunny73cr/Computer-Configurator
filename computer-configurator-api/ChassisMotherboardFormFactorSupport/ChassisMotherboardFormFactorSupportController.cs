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

        [HttpPost]
        public async Task<ActionResult> Create(Guid chassisUUID, DTO.Create createChassisMotherboardFormFactorSupport)
        {
            IReadOnlyList<string> errors = createChassisMotherboardFormFactorSupport.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool existing = await _context.ChassisMotherboardFormFactorSupport.AnyAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.MotherboardFormFactorUUID == createChassisMotherboardFormFactorSupport.MotherboardFormFactorUUID
            );

            if (existing) return Conflict();

            bool chassisExists = await _context.Chassis.AnyAsync(x => x.UUID == chassisUUID);

            if (chassisExists == false) return NotFound();

            bool motherboardFormFactorExists = await _context.MotherboardFormFactor.AnyAsync(x => x.UUID == createChassisMotherboardFormFactorSupport.MotherboardFormFactorUUID);

            if (motherboardFormFactorExists == false) return NotFound();

            ChassisMotherboardFormFactorSupport ChassisMotherboardFormFactorSupport = new(chassisUUID, createChassisMotherboardFormFactorSupport);

            _context.ChassisMotherboardFormFactorSupport.Add(ChassisMotherboardFormFactorSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<DTO.Details>>> GetAll(Guid chassisUUID)
        {
            List<DTO.Details> ChassisMotherboardFormFactorSupport = new();

            IAsyncEnumerable<ChassisMotherboardFormFactorSupport> query = _context.ChassisMotherboardFormFactorSupport
                .Include(x => x.MotherboardFormFactor)
                .Where(x => x.ChassisUUID == chassisUUID)
                .AsAsyncEnumerable();

            await foreach (ChassisMotherboardFormFactorSupport chassisMotherboardFormFactorSupport in query)
            {
                ChassisMotherboardFormFactorSupport.Add(new DTO.Details(chassisMotherboardFormFactorSupport));
            }

            return Ok(ChassisMotherboardFormFactorSupport);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid chassisUUID, Guid motherboardFormFactorUUID)
        {
            ChassisMotherboardFormFactorSupport? motherboardFormFactorSupport = await _context.ChassisMotherboardFormFactorSupport.FirstOrDefaultAsync(x =>
                x.ChassisUUID == chassisUUID
                && x.MotherboardFormFactorUUID == motherboardFormFactorUUID
            );

            if (motherboardFormFactorSupport == null) return NotFound();

            _context.ChassisMotherboardFormFactorSupport.Remove(motherboardFormFactorSupport);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
