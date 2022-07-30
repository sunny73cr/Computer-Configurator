using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.NVMESSD
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class NVMESSDController : ControllerBase
    {
        private readonly CCContext _context;

        public NVMESSDController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createNVMESSD)
        {
            var errors = createNVMESSD.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createNVMESSD.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createNVMESSD)) return Conflict();

            bool NVMEFormFactorExists = await _context.NVMEFormFactor.AnyAsync(x => x.UUID == createNVMESSD.NVMEFormFactorUUID);

            if (NVMEFormFactorExists == false) return NotFound();

            bool NVMEInterfaceExists = await _context.NVMEInterface.AnyAsync(x => x.UUID == createNVMESSD.NVMEInterfaceUUID);

            if (NVMEInterfaceExists == false) return NotFound();

            NVMESSD NVMESSD = new(createNVMESSD);

            _context.NVMESSD.Add(NVMESSD);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> NVMESSDs = new();

            IAsyncEnumerable<NVMESSD> query = _context.NVMESSD
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.Storage)
                .Include(x => x.NVMEFormFactor)
                .Include(x => x.NVMEInterface)
                .AsAsyncEnumerable();

            await foreach (NVMESSD NVMESSD in query)
            {
                NVMESSDs.Add(new DTO.Details(NVMESSD));
            }

            return Ok(NVMESSDs);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            NVMESSD? NVMESSD = await _context.NVMESSD
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.Storage)
                .Include(x => x.NVMEFormFactor)
                .Include(x => x.NVMEInterface)
                .FirstOrDefaultAsync(NVMESSD => NVMESSD.UUID == uuid);

            if (NVMESSD == null) return NotFound();

            var details = new DTO.Details(NVMESSD);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit NVMESSDEdits)
        {
            IReadOnlyList<string> errors = NVMESSDEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            NVMESSD? NVMESSD = await _context.NVMESSD.FirstOrDefaultAsync(x => x.UUID == NVMESSDEdits.UUID);

            if (NVMESSD == null) return NotFound();

            if (NVMESSD.ManufacturerUUID != NVMESSDEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == NVMESSDEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (NVMESSD.Model.ToLower() != NVMESSDEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, NVMESSDEdits);

                    if (duplicate) return Conflict();
                }
            }

            if (NVMESSD.NVMEFormFactorUUID != NVMESSDEdits.NVMEFormFactorUUID)
            {
                bool NVMEFormFactorExists = await _context.NVMEFormFactor.AnyAsync(x => x.UUID == NVMESSDEdits.NVMEFormFactorUUID);

                if (NVMEFormFactorExists == false) return NotFound();
            }

            if (NVMESSD.NVMEInterfaceUUID != NVMESSDEdits.NVMEInterfaceUUID)
            {
                bool NVMEInterfaceExists = await _context.NVMEInterface.AnyAsync(x => x.UUID == NVMESSDEdits.NVMEInterfaceUUID);

                if (NVMEInterfaceExists == false) return NotFound();
            }

            NVMESSD.Edit(NVMESSD, NVMESSDEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            NVMESSD? NVMESSD = await _context.NVMESSD.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (NVMESSD == null) return NotFound();

            _context.NVMESSD.Remove(NVMESSD);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
