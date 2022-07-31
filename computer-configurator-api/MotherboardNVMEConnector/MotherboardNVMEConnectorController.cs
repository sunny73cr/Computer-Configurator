using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.MotherboardNVMEConnector
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class MotherboardNVMEConnectorController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardNVMEConnectorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid motherboardUUID, DTO.Create createMotherboardNVMEConnector)
        {
            IReadOnlyList<string> errors = createMotherboardNVMEConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool motherboardExists = await _context.Motherboard.AnyAsync(x => x.UUID == motherboardUUID);

            if (motherboardExists == false) return NotFound();

            bool pcieGenerationExists = await _context.PCIEGeneration.AnyAsync(x => x.UUID == createMotherboardNVMEConnector.PCIEGenerationUUID);

            if (pcieGenerationExists == false) return NotFound();

            bool nvmeInterfaceExists = await _context.NVMEInterface.AnyAsync(x => x.UUID == createMotherboardNVMEConnector.NVMEInterfaceUUID);

            if (nvmeInterfaceExists == false) return NotFound();

            bool nvmeFormFactorExists = await _context.NVMEFormFactor.AnyAsync(x => x.UUID == createMotherboardNVMEConnector.NVMEFormFactorUUID);

            if (pcieGenerationExists == false) return NotFound();

            bool duplicate = await _context.MotherboardNVMEConnector.AnyAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.PCIEGenerationUUID == createMotherboardNVMEConnector.PCIEGenerationUUID
                && x.NVMEInterfaceUUID == createMotherboardNVMEConnector.NVMEInterfaceUUID
                && x.NVMEFormFactorUUID == createMotherboardNVMEConnector.NVMEFormFactorUUID
            );

            if (duplicate) return Conflict();

            MotherboardNVMEConnector MotherboardNVMEConnector = new(motherboardUUID, createMotherboardNVMEConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll(Guid motherboardUUID)
        {
            HashSet<DTO.Details> MotherboardNVMEConnectorDetails = new();

            IAsyncEnumerable<MotherboardNVMEConnector> query = _context.MotherboardNVMEConnector
                .Include(x => x.PCIEGeneration)
                .Include(x => x.NVMEInterface)
                .Include(x => x.NVMEFormFactor)
                .Where(x => x.MotherboardUUID == motherboardUUID)
                .AsAsyncEnumerable();

            await foreach (MotherboardNVMEConnector MotherboardNVMEConnector in query)
            {
                MotherboardNVMEConnectorDetails.Add(new DTO.Details(MotherboardNVMEConnector));
            }

            return Ok(MotherboardNVMEConnectorDetails);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid motherboardUUID, Guid pcieGenerationUUID, Guid nvmeInterfaceUUID, Guid nvmeFormFactorUUID)
        {
            MotherboardNVMEConnector? MotherboardNVMEConnector = await _context.MotherboardNVMEConnector
                .Include(x => x.PCIEGeneration)
                .Include(x => x.NVMEInterface)
                .Include(x => x.NVMEFormFactor)
                .FirstOrDefaultAsync(x =>
                    x.MotherboardUUID == motherboardUUID
                    && x.PCIEGenerationUUID == pcieGenerationUUID
                    && x.NVMEInterfaceUUID == nvmeInterfaceUUID
                    && x.NVMEFormFactorUUID == nvmeFormFactorUUID
                );

            if (MotherboardNVMEConnector == null) return NotFound();

            DTO.Details MotherboardNVMEConnectorDetails = new(MotherboardNVMEConnector);

            return Ok(MotherboardNVMEConnectorDetails);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(Guid motherboardUUID, DTO.Edit editMotherboardNVMEConnector)
        {
            IReadOnlyList<string> errors = editMotherboardNVMEConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            MotherboardNVMEConnector? MotherboardNVMEConnector = await _context.MotherboardNVMEConnector.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.PCIEGenerationUUID == editMotherboardNVMEConnector.PCIEGenerationUUID
                && x.NVMEInterfaceUUID == editMotherboardNVMEConnector.NVMEInterfaceUUID
                && x.NVMEFormFactorUUID == editMotherboardNVMEConnector.NVMEFormFactorUUID
            );

            if (MotherboardNVMEConnector == null) return NotFound();

            MotherboardNVMEConnector.Edit(MotherboardNVMEConnector, editMotherboardNVMEConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid motherboardUUID, Guid pcieGenerationUUID, Guid nvmeInterfaceUUID, Guid nvmeFormFactorUUID)
        {
            MotherboardNVMEConnector? MotherboardNVMEConnector = await _context.MotherboardNVMEConnector.FirstOrDefaultAsync(x =>
                x.MotherboardUUID == motherboardUUID
                && x.PCIEGenerationUUID == pcieGenerationUUID
                && x.NVMEInterfaceUUID == nvmeInterfaceUUID
                && x.NVMEFormFactorUUID == nvmeFormFactorUUID
            );

            if (MotherboardNVMEConnector == null) return NotFound();

            _context.MotherboardNVMEConnector.Remove(MotherboardNVMEConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

