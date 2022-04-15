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

    // [HttpGet("{id:length(24)}")]
    // public async Task<ActionResult<Book>> Get(string id)
    // {
    //     var book = await _booksService.GetAsync(id);

    //     if (book is null)
    //     {
    //         return NotFound();
    //     }

    //     return book;
    // }

    // [HttpPost]
    // public async Task<IActionResult> Post(Book newBook)
    // {
    //     await _booksService.CreateAsync(newBook);

    //     return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    // }

    // [HttpPut("{id:length(24)}")]
    // public async Task<IActionResult> Update(string id, Book updatedBook)
    // {
    //     var book = await _booksService.GetAsync(id);

    //     if (book is null)
    //     {
    //         return NotFound();
    //     }

    //     updatedBook.Id = book.Id;

    //     await _booksService.UpdateAsync(id, updatedBook);

    //     return NoContent();
    // }

    // [HttpDelete("{id:length(24)}")]
    // public async Task<IActionResult> Delete(string id)
    // {
    //     var book = await _booksService.GetAsync(id);

    //     if (book is null)
    //     {
    //         return NotFound();
    //     }

    //     await _booksService.RemoveAsync(id);

    //     return NoContent();
    // }
}