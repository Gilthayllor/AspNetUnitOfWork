using AspNetUnityOfWork.Application.ViewModel;
using AspNetUnityOfWork.Data.Entities;
using AspNetUnityOfWork.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspNetUnityOfWork.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnityOfWorkRepository _unityOfWorkRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public BooksController(IUnityOfWorkRepository unityOfWorkRepository, IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _unityOfWorkRepository = unityOfWorkRepository;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookRepository.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBookById([FromQuery] int id)
        {
            try
            {
                return Ok(await _bookRepository.GetByIdAsync(id));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookViewModel createBook)
        {
            try
            {
                var newBook = new Book(createBook.Name, createBook.AuthorId);

                await _bookRepository.InsertAsync(newBook);
                await _authorRepository.UpdateBookCountAsync(createBook.AuthorId);

                await _unityOfWorkRepository.CommitAsync();

                return Ok(newBook);
            }
            catch (Exception e)
            {
                await _unityOfWorkRepository.Rollback();

                return StatusCode(500, e.Message);
            }
        }
    }
}
