using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.GPUDisplayConnector
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class GPUDisplayConnectorController : ControllerBase
    {
        private readonly CCContext _context;

        public GPUDisplayConnectorController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guid gpuUUID, DTO.Create createGPUDisplayConnector)
        {
            IReadOnlyList<string> errors = createGPUDisplayConnector.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool gpuExists = await _context.GPU.AnyAsync(x => x.UUID == gpuUUID);

            if (gpuExists == false) return NotFound();

            bool displayConnectorExists = await _context.DisplayConnector.AnyAsync(x => x.UUID == createGPUDisplayConnector.DisplayConnectorUUID);

            if (displayConnectorExists == false) return NotFound();

            bool duplicate = await _context.GPUDisplayConnector.AnyAsync(x =>
                x.GPUUUID == gpuUUID
                && x.DisplayConnectorUUID == createGPUDisplayConnector.DisplayConnectorUUID
            );

            if (duplicate) return Conflict();

            GPUDisplayConnector gpuDisplayConnector = new(gpuUUID, createGPUDisplayConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll(Guid gpuUUID)
        {
            List<DTO.Details> GPUDisplayConnectors = new();

            IAsyncEnumerable<GPUDisplayConnector> query = _context.GPUDisplayConnector
                .Include(x => x.DisplayConnector)
                .Where(x => x.GPUUUID == gpuUUID)
                .AsAsyncEnumerable();

            await foreach (GPUDisplayConnector gpuDisplayConnector in query)
            {
                GPUDisplayConnectors.Add(new DTO.Details(gpuDisplayConnector));
            }

            return Ok(GPUDisplayConnectors);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid gpuUUID, Guid displayConnectorUUID)
        {
            GPUDisplayConnector? gpuDisplayConnector = await _context.GPUDisplayConnector.FirstOrDefaultAsync(x =>
                x.GPUUUID == gpuUUID
                && x.DisplayConnectorUUID == displayConnectorUUID
            );

            if (gpuDisplayConnector == null) return NotFound();

            _context.GPUDisplayConnector.Remove(gpuDisplayConnector);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
