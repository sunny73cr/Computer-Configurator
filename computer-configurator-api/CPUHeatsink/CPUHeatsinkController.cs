using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.CPUHeatsink
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class CPUHeatsinkController : ControllerBase
    {
        private readonly CCContext _context;

        public CPUHeatsinkController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createCPUHeatsink)
        {
            var errors = createCPUHeatsink.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createCPUHeatsink.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createCPUHeatsink)) return Conflict();

            foreach (CPUCoolerFan.DTO.Create createCPUCoolerFan in createCPUHeatsink.CPUCoolerFans)
            {
                bool fanExists = await _context.Fan.AnyAsync(x => x.UUID == createCPUCoolerFan.FanUUID);

                if (fanExists == false) return NotFound();
            }

            foreach (CPUCoolerCPUSocketSupport.DTO.Create createCPUCoolerSocketSupport in createCPUHeatsink.CPUCoolerCPUSocketSupport)
            {
                bool cpuSocketExists = await _context.CPUSocket.AnyAsync(x => x.UUID == createCPUCoolerSocketSupport.CPUSocketUUID);

                if (cpuSocketExists == false) return NotFound();
            }

            CPUHeatsink CPUHeatsink = new(createCPUHeatsink);

            _context.CPUHeatsink.Add(CPUHeatsink);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> CPUHeatsinks = new();

            IAsyncEnumerable<CPUHeatsink> query = _context.CPUHeatsink
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.CPUCoolerFans)
                .Include(x => x.CPUSockets)
                .AsAsyncEnumerable();

            await foreach (CPUHeatsink cpuHeatsink in query)
            {
                CPUHeatsinks.Add(new DTO.Details(cpuHeatsink));
            }

            return Ok(CPUHeatsinks);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            CPUHeatsink? CPUHeatsink = await _context.CPUHeatsink
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .Include(x => x.CPUCoolerFans)
                .Include(x => x.CPUSockets)
                .FirstOrDefaultAsync(CPUHeatsink => CPUHeatsink.UUID == uuid);

            if (CPUHeatsink == null) return NotFound();

            DTO.Details CPUHeatsinkDetails = new(CPUHeatsink);

            return Ok(CPUHeatsinkDetails);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit CPUHeatsinkEdits)
        {
            IReadOnlyList<string> errors = CPUHeatsinkEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            CPUHeatsink? CPUHeatsink = await _context.CPUHeatsink.FirstOrDefaultAsync(x => x.UUID == CPUHeatsinkEdits.UUID);

            if (CPUHeatsink == null) return NotFound();

            if (CPUHeatsink.ManufacturerUUID != CPUHeatsinkEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == CPUHeatsinkEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (CPUHeatsink.Model.ToLower() != CPUHeatsinkEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, CPUHeatsinkEdits);

                    if (duplicate) return Conflict();
                }
            }

            CPUHeatsink.Edit(CPUHeatsink, CPUHeatsinkEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            CPUHeatsink? CPUHeatsink = await _context.CPUHeatsink.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (CPUHeatsink == null) return NotFound();

            _context.CPUHeatsink.Remove(CPUHeatsink);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
