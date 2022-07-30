using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.SATAHDD
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class SATAHDDController : ControllerBase
    {
        private readonly CCContext _context;

        public SATAHDDController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createSATAHDD)
        {
            var errors = createSATAHDD.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createSATAHDD.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createSATAHDD)) return Conflict();

            bool MountedStorageFormFactorExists = await _context.MountedStorageFormFactor.AnyAsync(x => x.UUID == createSATAHDD.MountedStorageFormFactorUUID);

            if (MountedStorageFormFactorExists == false) return NotFound();

            SATAHDD SATAHDD = new(createSATAHDD);

            _context.SATAHDD.Add(SATAHDD);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> SATAHDDs = new();

            IAsyncEnumerable<SATAHDD> query = _context.SATAHDD
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.Storage)
                .Include(x => x.MountedStorageFormFactor)
                .AsAsyncEnumerable();

            await foreach (SATAHDD SATAHDD in query)
            {
                SATAHDDs.Add(new DTO.Details(SATAHDD));
            }

            return Ok(SATAHDDs);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            SATAHDD? SATAHDD = await _context.SATAHDD
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.Storage)
                .Include(x => x.MountedStorageFormFactor)
                .FirstOrDefaultAsync(SATAHDD => SATAHDD.UUID == uuid);

            if (SATAHDD == null) return NotFound();

            var details = new DTO.Details(SATAHDD);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit SATAHDDEdits)
        {
            IReadOnlyList<string> errors = SATAHDDEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            SATAHDD? SATAHDD = await _context.SATAHDD.FirstOrDefaultAsync(x => x.UUID == SATAHDDEdits.UUID);

            if (SATAHDD == null) return NotFound();

            if (SATAHDD.ManufacturerUUID != SATAHDDEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == SATAHDDEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (SATAHDD.Model.ToLower() != SATAHDDEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, SATAHDDEdits);

                    if (duplicate) return Conflict();
                }
            }

            if (SATAHDD.MountedStorageFormFactorUUID != SATAHDDEdits.MountedStorageFormFactorUUID)
            {
                bool mountedStorageFormFactorExists = await _context.MountedStorageFormFactor.AnyAsync(x => x.UUID == SATAHDDEdits.MountedStorageFormFactorUUID);

                if (mountedStorageFormFactorExists == false) return NotFound();
            }

            SATAHDD.Edit(SATAHDD, SATAHDDEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            SATAHDD? SATAHDD = await _context.SATAHDD.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (SATAHDD == null) return NotFound();

            _context.SATAHDD.Remove(SATAHDD);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
