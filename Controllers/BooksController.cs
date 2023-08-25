using BooksStore.Data;
using BooksStore.DTOs.Books;
using BooksStore.Repositories.Books;
using BooksStore.Services.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        #region Setup

        private readonly IBooksRepository booksRepository;
        public BooksController(IBooksRepository _booksRepository)
        {
            booksRepository = _booksRepository;
        }

        #endregion

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBookDTO>>> GetBooks(string? title, DateTime? date)
        {
            var res = await booksRepository.GetBooks(title, date);
            return res.Success ? Ok(res) : NotFound(res.Message);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBookDTO>> GetBook(int id)
        {
            var res = await booksRepository.GetBook(id);
            return res.Success ? Ok(res) : NotFound(res.Message);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook(AddBookDTO book)
        {
            var res = await booksRepository.CreateBook(book);
            return res.Success ? Ok(res) : BadRequest(res.Message);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook(UpdateBookDTO book)
        {
            var res = await booksRepository.UpdateBook(book);
            return res.Success ? Ok(res) : BadRequest(res.Message);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await booksRepository.DeleteBook(id);
            return Ok();
        }
    }
}
