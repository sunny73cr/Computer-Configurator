using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.CPUClosedLoopCooler
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class CPUClosedLoopCoolerController : ControllerBase
    {
        private readonly CCContext _context;

        public CPUClosedLoopCoolerController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createCPUClosedLoopCooler)
        {
            var errors = createCPUClosedLoopCooler.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createCPUClosedLoopCooler.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createCPUClosedLoopCooler)) return Conflict();

            bool radiatorSizeExists = await _context.RadiatorSize.AnyAsync(x => x.UUID == createCPUClosedLoopCooler.RadiatorSizeUUID);

            if (radiatorSizeExists == false) return NotFound();

            foreach (CPUCoolerFan.DTO.Create createCPUCoolerFan in createCPUClosedLoopCooler.CPUCoolerFans)
            {
                bool fanExists = await _context.Fan.AnyAsync(x => x.UUID == createCPUCoolerFan.FanUUID);

                if (fanExists == false) return NotFound();
            }

            foreach (CPUCoolerCPUSocketSupport.DTO.Create createCPUCoolerSocketSupport in createCPUClosedLoopCooler.CPUCoolerCPUSocketSupport)
            {
                bool cpuSocketExists = await _context.CPUSocket.AnyAsync(x => x.UUID == createCPUCoolerSocketSupport.CPUSocketUUID);

                if (cpuSocketExists == false) return NotFound();
            }

            CPUClosedLoopCooler CPUClosedLoopCooler = new(createCPUClosedLoopCooler);

            _context.CPUClosedLoopCooler.Add(CPUClosedLoopCooler);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> CPUClosedLoopCoolers = new();

            IAsyncEnumerable<CPUClosedLoopCooler> query = _context.CPUClosedLoopCooler
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.CPUCooler)
                .Include(x => x.CPUCoolerFans)
                .Include(x => x.CPUSockets)
                .Include(x => x.RadiatorSize)
                .AsAsyncEnumerable();

            await foreach (CPUClosedLoopCooler cpuClosedLoopCooler in query)
            {
                CPUClosedLoopCoolers.Add(new DTO.Details(cpuClosedLoopCooler));
            }

            return Ok(CPUClosedLoopCoolers);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            CPUClosedLoopCooler? CPUClosedLoopCooler = await _context.CPUClosedLoopCooler
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.CPUCooler)
                .Include(x => x.CPUCoolerFans)
                .Include(x => x.CPUSockets)
                .Include(x => x.RadiatorSize)
                .FirstOrDefaultAsync(CPUClosedLoopCooler => CPUClosedLoopCooler.UUID == uuid);

            if (CPUClosedLoopCooler == null) return NotFound();

            DTO.Details CPUClosedLoopCoolerDetails = new(CPUClosedLoopCooler);

            return Ok(CPUClosedLoopCoolerDetails);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit CPUClosedLoopCoolerEdits)
        {
            IReadOnlyList<string> errors = CPUClosedLoopCoolerEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            CPUClosedLoopCooler? CPUClosedLoopCooler = await _context.CPUClosedLoopCooler.FirstOrDefaultAsync(x => x.UUID == CPUClosedLoopCoolerEdits.UUID);

            if (CPUClosedLoopCooler == null) return NotFound();

            if (CPUClosedLoopCooler.ManufacturerUUID != CPUClosedLoopCoolerEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == CPUClosedLoopCoolerEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (CPUClosedLoopCooler.Model.ToLower() != CPUClosedLoopCoolerEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, CPUClosedLoopCoolerEdits);

                    if (duplicate) return Conflict();
                }
            }

            if (CPUClosedLoopCooler.RadiatorSizeUUID != CPUClosedLoopCoolerEdits.RadiatorSizeUUID)
            {
                bool radiatorSizeExists = await _context.RadiatorSize.AnyAsync(x => x.UUID == CPUClosedLoopCoolerEdits.RadiatorSizeUUID);

                if (radiatorSizeExists == false) return NotFound();
            }

            CPUClosedLoopCooler.Edit(CPUClosedLoopCooler, CPUClosedLoopCoolerEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            CPUClosedLoopCooler? CPUClosedLoopCooler = await _context.CPUClosedLoopCooler.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (CPUClosedLoopCooler == null) return NotFound();

            _context.CPUClosedLoopCooler.Remove(CPUClosedLoopCooler);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
