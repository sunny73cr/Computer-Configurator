using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardSATAConnector
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class MotherboardSATAConnectorController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardSATAConnectorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid motherboardUUID, DTO.Create createMotherboardSATAConnector)
        {
            IReadOnlyList<string> errors = createMotherboardSATAConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool motherboardExists = await _context.Motherboard.AnyAsync(x => x.UUID == motherboardUUID);

            if (motherboardExists == false) return NotFound();

            bool sataGenerationExists = await _context.SATAGeneration.AnyAsync(x => x.UUID == createMotherboardSATAConnector.SATAGenerationUUID);

            if (sataGenerationExists == false) return NotFound();

            bool duplicate = await _context.MotherboardSATAConnector.AnyAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.SATAGenerationUUID == createMotherboardSATAConnector.SATAGenerationUUID
            );

            if (duplicate) return Conflict();

            MotherboardSATAConnector MotherboardSATAConnector = new(motherboardUUID, createMotherboardSATAConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll(Guid motherboardUUID)
        {
            HashSet<DTO.Details> MotherboardSATAConnectorDetails = new();

            IAsyncEnumerable<MotherboardSATAConnector> query = _context.MotherboardSATAConnector
                .Include(x => x.SATAGeneration)
                .Where(x => x.MotherboardUUID == motherboardUUID)
                .AsAsyncEnumerable();

            await foreach (MotherboardSATAConnector MotherboardSATAConnector in query)
            {
                MotherboardSATAConnectorDetails.Add(new DTO.Details(MotherboardSATAConnector));
            }

            return Ok(MotherboardSATAConnectorDetails);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid motherboardUUID, Guid MotherboardSATAConnectorUUID)
        {
            MotherboardSATAConnector? MotherboardSATAConnector = await _context.MotherboardSATAConnector
                .Include(x => x.SATAGeneration)
                .FirstOrDefaultAsync(
                    x => x.MotherboardUUID == motherboardUUID
                    && x.SATAGenerationUUID == MotherboardSATAConnectorUUID
                );

            if (MotherboardSATAConnector == null) return NotFound();

            DTO.Details MotherboardSATAConnectorDetails = new(MotherboardSATAConnector);

            return Ok(MotherboardSATAConnectorDetails);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid motherboardUUID, DTO.Edit editMotherboardSATAConnector)
        {
            IReadOnlyList<string> errors = editMotherboardSATAConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardSATAConnector? MotherboardSATAConnector = await _context.MotherboardSATAConnector.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.SATAGenerationUUID == editMotherboardSATAConnector.SATAGenerationUUID
            );

            if (MotherboardSATAConnector == null) return NotFound();

            MotherboardSATAConnector.Edit(MotherboardSATAConnector, editMotherboardSATAConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid motherboardUUID, Guid MotherboardSATAConnectorUUID)
        {
            MotherboardSATAConnector? MotherboardSATAConnector = await _context.MotherboardSATAConnector.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.SATAGenerationUUID == MotherboardSATAConnectorUUID
            );

            if (MotherboardSATAConnector == null) return NotFound();

            _context.MotherboardSATAConnector.Remove(MotherboardSATAConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

