//using LibraryManager.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace LibraryManager.Controllers;

//[Route("api/[controller]")]
//[ApiController]

//public class BooksController : ControllerBase
//{
//    private static readonly List<Book> _books = new List<Book>();

//    [HttpGet]
//    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
//    public IActionResult GetBooks()
//    {
//        if (_books.Count == 0)
//        {
//            return NotFound("Nenhum livro cadastrado.");
//        }
//        return Ok(_books);
//    }

//    [HttpPost]
//    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
//    public IActionResult CreateBook([FromBody] Book requestNewBook)
//    {
//        if (ModelState.IsValid == false)
//        {
//            return BadRequest(ModelState);
//        }

//        var newBook = new Book
//        {
//            Id = _books.Count + 1,
//            Title = requestNewBook.Title,
//            Author = requestNewBook.Author,
//            Genre = requestNewBook.Genre,
//            Price = requestNewBook.Price,
//            Quantity = requestNewBook.Quantity
//        };

//        _books.Add(newBook);
//        return CreatedAtRoute("GetBook", new { id = newBook.Id }, newBook);
//    }

//    [HttpGet]
//    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
//    [Route("{id}")]
//    public IActionResult GetBookById([FromRoute] int id)
//    {
//        var book = _books.Find(bookFind => bookFind.Id == id);

//        if (book == null)
//            return NotFound("Esse livro não existe");

//        return Ok(book);
//    }

//    [HttpPut]
//    [Route("{id}")]
//    [ProducesResponseType(StatusCodes.Status204NoContent)]
//    public IActionResult UpdateBook([FromRoute] int id, Book request)
//    {
//        if (!ModelState.IsValid)
//        {
//            return BadRequest(ModelState);
//        }

//        var book = _books.Find(bookFind => bookFind.Id == id);

//        if (book == null)
//        {
//            return NotFound("Esse livro não existe");
//        }

//        book.Title = request.Title;
//        book.Author = request.Author;
//        book.Genre = request.Genre;
//        book.Price = request.Price;
//        book.Quantity = request.Quantity;

//        return NoContent();
//    }

//    [HttpDelete]
//    [Route("{id}")]
//    [ProducesResponseType(StatusCodes.Status204NoContent)]
//    public IActionResult DeleteBook([FromRoute] int id)
//    {
//        var deletedBook = _books.Find(bookFind => bookFind.Id == id);

//        if (deletedBook == null)
//        {
//            return NotFound("Esse livro não existe para ser excluído");
//        }

//        _books.Remove(deletedBook);

//        return NoContent();
//    }
//}