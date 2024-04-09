using LibraryManager.Communication.Requests;
using LibraryManager.Communication.Responses;
using LibraryManager.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private static readonly List<Book> _books = new List<Book>();

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetBooks()
    {
        if (_books.Count == 0)
        {
            return NotFound("Nenhum livro cadastrado.");
        }
        return Ok(_books);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateBookResponse), StatusCodes.Status201Created)]
    public IActionResult CreateBook([FromBody] CreateBookRequest request)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }

        // Generate a unique ID (e.g., using a library or database)
        string generatedId = Guid.NewGuid().ToString();

        var newBook = new Book
        {
            Id = generatedId,
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Quantity = request.Quantity
        };

        _books.Add(newBook);

        // Create response object
        var response = new CreateBookResponse
        {
            Id = generatedId,
        };

        // **Correction:** Use the correct route name ("GetBookById")
        return CreatedAtRoute("GetBookById", new { id = generatedId }, response);
    }


    [HttpGet]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [Route("{id}")]
    public IActionResult GetBookById([FromRoute] string id)
    {
        var book = _books.Find(bookFind => bookFind.Id == id);

        if (book == null)
            return NotFound("Esse livro não existe");

        return Ok(book);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult UpdateBook([FromRoute] string id, UpdateBookRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var book = _books.Find(bookFind => bookFind.Id == id);

        if (book == null)
        {
            return NotFound("Esse livro não existe");
        }

        book.Id = request.Id;
        book.Title = request.Title;
        book.Author = request.Author;
        book.Genre = request.Genre;
        book.Price = request.Price;
        book.Quantity = request.Quantity;

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteBook([FromRoute] string id)
    {
        var deletedBook = _books.Find(bookFind => bookFind.Id == id);

        if (deletedBook == null)
        {
            return NotFound("Esse livro não existe para ser excluído");
        }

        _books.Remove(deletedBook);

        return NoContent();
    }
}
