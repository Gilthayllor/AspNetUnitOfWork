using AspNetUnityOfWork.Data.Entities;
using AspNetUnityOfWork.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetUnityOfWork.Data.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dataContext;

        public BookRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _dataContext.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await _dataContext.Books.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (book == null)
                throw new Exception("Book not found.");

            return book;
        }

        public async Task InsertAsync(Book book)
        {
            try
            {
                await _dataContext.Books.AddAsync(book);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
