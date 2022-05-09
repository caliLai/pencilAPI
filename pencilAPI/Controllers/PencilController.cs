using pencilAPI.Models;
using pencilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace pencilAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PencilController : ControllerBase
{
    private readonly PencilService _pencilService;

    public PencilController(PencilService pencilService) => _pencilService = pencilService;

    [HttpGet]
    // public async Task<List<Pencil>> Get() => await _pencilService.GetAsync();
    public async Task<IActionResult> Get() {
		 var result = await _pencilService.GetAsync();
        if (result.Count == 0)
        {
            return NoContent();
        }
        return Ok(result);
	}

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Pencil>> Get(string id)
    {
        var pencil = await _pencilService.GetAsync(id);

        if (pencil is null) {
            return NotFound();
        }

        return pencil;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Pencil newPencil)
    {
        await _pencilService.CreateAsync(newPencil);

        return CreatedAtAction(nameof(Get), new { id = newPencil.Id }, newPencil);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Pencil updatedPencil)
    {
        var pencil = await _pencilService.GetAsync(id);

        if (pencil is null)
        {
            return NotFound();
        }

        updatedPencil.Id = pencil.Id;

        await _pencilService.UpdateAsync(id, updatedPencil);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var pencil = await _pencilService.GetAsync(id);

        if (pencil is null)
        {
            return NotFound();
        }

        await _pencilService.RemoveAsync(id);

        return NoContent();
    }
}