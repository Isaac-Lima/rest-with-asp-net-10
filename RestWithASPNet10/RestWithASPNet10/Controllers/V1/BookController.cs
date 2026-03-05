using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10.Data.DTO.V1;
using RestWithASPNet10.Services;

namespace RestWithASPNet10.Controllers.V1
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all books");
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Getting book with id {Id}", id);

            var book = _bookService.FindById(id);

            if (book == null)
            {
                _logger.LogWarning("Book with id {Id} not found", id);
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDTO book)
        {
            _logger.LogInformation("Creating a new book: {title}", book.Title);

            var createdBook = _bookService.Create(book);

            if (createdBook == null)
            {
                _logger.LogError("Failed to create book: {title}", book.Title);
                return BadRequest();
            }

            return Ok(book);
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookDTO book)
        {
            _logger.LogInformation("Updating book with id {Id}", book.Id);
            var updatedBook = _bookService.Update(book);
            if (updatedBook == null)
            {
                _logger.LogWarning("Book with id {Id} not found for update", book.Id);
                return NotFound();
            }

            _logger.LogInformation("Book with id {Id} updated successfully", book.Id);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var book = _bookService.FindById(id);

            if (book == null)
            {
                _logger.LogWarning("Book with id {Id} not found for deletion", id);
                return NotFound();
            }

            _logger.LogInformation("Deleting book with id {Id}", id);
            _bookService.Delete(id);

            _logger.LogInformation("Book with id {Id} deleted successfully", id);
            return NoContent();
        }
    }
}
