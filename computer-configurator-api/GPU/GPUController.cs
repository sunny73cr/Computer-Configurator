using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.GPU
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class GPUController : ControllerBase
    {
        private readonly CCContext _context;

        public GPUController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createGPU)
        {
            var errors = createGPU.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createGPU.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createGPU)) return Conflict();

            PCIEConnector.PCIEConnector? pcieConnector = await _context.PCIEConnector.FirstOrDefaultAsync(x => x.UUID == createGPU.PCIEConnectorUUID);

            if (pcieConnector == null) return NotFound();

            foreach (GPUDisplayConnector.DTO.Create createGPUDisplayConnector in createGPU.GPUDisplayConnectors)
            {
                DisplayConnector.DisplayConnector? displayConnector = await _context.DisplayConnector.FirstOrDefaultAsync(x => x.UUID == createGPUDisplayConnector.DisplayConnectorUUID);
            
                if (displayConnector == null) return NotFound();
            }

            GPU GPU = new(createGPU);

            _context.GPU.Add(GPU);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid uuid)
        {
            GPU? GPU = await _context.GPU
                .Include(GPU => GPU.PCIEConnector)
                .ThenInclude(x => x.PCIEGeneration)
                .Include(GPU => GPU.Part)
                .ThenInclude(part => part.Manufacturer)
                .FirstOrDefaultAsync(GPU => GPU.UUID == uuid);

            if (GPU == null) return NotFound();

            var details = new DTO.Details(GPU);

            return Ok(details);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(DTO.Edit GPUEdits)
        {
            IReadOnlyList<string> errors = GPUEdits.Validate();

            if (errors.Any()) return BadRequest(errors);

            GPU? GPU = await _context.GPU.FirstOrDefaultAsync(x => x.UUID == GPUEdits.UUID);

            if (GPU == null) return NotFound();

            if (GPU.ManufacturerUUID != GPUEdits.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == GPUEdits.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (GPU.Model.ToLower() != GPUEdits.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, GPUEdits);

                    if (duplicate) return Conflict();
                }
            }

            GPU.Edit(GPU, GPUEdits);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            GPU? placeholder = await _context.GPU.FirstOrDefaultAsync(x => x.UUID == uuid);

            if (placeholder == null) return NotFound();

            _context.GPU.Remove(placeholder);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
