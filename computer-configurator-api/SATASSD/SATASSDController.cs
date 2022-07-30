using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.SATASSD
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class SATASSDController : ControllerBase
    {
        private readonly CCContext _context;

        public SATASSDController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createSATASSD)
        {
            var errors = createSATASSD.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createSATASSD.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createSATASSD)) return Conflict();

            bool MountedStorageFormFactorExists = await _context.MountedStorageFormFactor.AnyAsync(x => x.UUID == createSATASSD.MountedStorageFormFactorUUID);

            if (MountedStorageFormFactorExists == false) return NotFound();

            SATASSD SATASSD = new(createSATASSD);

            _context.SATASSD.Add(SATASSD);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> SATASSDs = new();

            IAsyncEnumerable<SATASSD> query = _context.SATASSD
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.Storage)
                .Include(x => x.MountedStorageFormFactor)
                .AsAsyncEnumerable();

            await foreach (SATASSD SATASSD in query)
            {
                SATASSDs.Add(new DTO.Details(SATASSD));
            }

            return Ok(SATASSDs);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            SATASSD? SATASSD = await _context.SATASSD
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.Storage)
                .Include(x => x.MountedStorageFormFactor)
                .FirstOrDefaultAsync(SATASSD => SATASSD.UUID == uuid);

            if (SATASSD == null) return NotFound();

            var details = new DTO.Details(SATASSD);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit SATASSDEdits)
        {
            IReadOnlyList<string> errors = SATASSDEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            SATASSD? SATASSD = await _context.SATASSD.FirstOrDefaultAsync(x => x.UUID == SATASSDEdits.UUID);

            if (SATASSD == null) return NotFound();

            if (SATASSD.ManufacturerUUID != SATASSDEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == SATASSDEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (SATASSD.Model.ToLower() != SATASSDEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, SATASSDEdits);

                    if (duplicate) return Conflict();
                }
            }

            if (SATASSD.MountedStorageFormFactorUUID != SATASSDEdits.MountedStorageFormFactorUUID)
            {
                bool mountedStorageFormFactorExists = await _context.MountedStorageFormFactor.AnyAsync(x => x.UUID == SATASSDEdits.MountedStorageFormFactorUUID);

                if (mountedStorageFormFactorExists == false) return NotFound();
            }

            SATASSD.Edit(SATASSD, SATASSDEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            SATASSD? SATASSD = await _context.SATASSD.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (SATASSD == null) return NotFound();

            _context.SATASSD.Remove(SATASSD);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
