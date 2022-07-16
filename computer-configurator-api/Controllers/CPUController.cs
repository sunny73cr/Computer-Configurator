using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComputerConfigurator.Api.Controllers;

[Route("/[Controller]/[Action]")]
[ApiController]
public class CPUController : ControllerBase
{
    //private readonly CCContext _context;

    //public CPUController(CCContext context)
    //{
    //    _context = context;
    //}

    [HttpGet]
    public async Task<ActionResult<bool>> ExistsById(int id)
    {
        bool exists = await DataAccess.Parts.CPU.Queries.ExistsById(id);

        if (exists) return NoContent();

        else return NotFound("Couldn't find that CPU");
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Domain.Parts.CPU.Create cpu)
    {
        var sw = Stopwatch.StartNew();

        var errors = cpu.Validate();

        if (errors.Any()) return BadRequest(errors);

        await DataAccess.Parts.CPU.Commands.Create(cpu);

        //return NoContent();

        sw.Stop();

        return Ok(sw.ElapsedMilliseconds);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Domain.Parts.CPU.Details>>> All()
    {
        IEnumerable<Domain.Parts.CPU.Details> cpus = await DataAccess.Parts.CPU.Queries.All();

        return Ok(cpus);
    }

    [HttpGet]
    public async Task<ActionResult<Domain.Parts.CPU.Details>> ById(int id)
    {
        var cpu = await DataAccess.Parts.CPU.Queries.ById(id);

        if (cpu == null) return NotFound("Couldn't find that CPU");

        return Ok(cpu);
    }

    [HttpPatch]
    public async Task<ActionResult<Domain.Parts.CPU.Details>> Edit(int id, [FromBody] Domain.Parts.CPU.Edit edits)
    {
        if (edits.HasEdits() == false) return BadRequest("No updates to process.");

        bool exists = await DataAccess.Parts.CPU.Queries.ExistsById(id);

        if (exists == false) return NotFound("Couldn't find that CPU");

        List<string> errors = edits.Validate();

        if (errors.Any()) return BadRequest(errors);

        await DataAccess.Parts.CPU.Commands.Edit(id, edits);

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var exists = await DataAccess.Parts.CPU.Queries.ExistsById(id);

        if (exists == false) return NotFound("Couldn't find that CPU");

        await DataAccess.Parts.CPU.Commands.Delete(id);

        return NoContent();
    }
}