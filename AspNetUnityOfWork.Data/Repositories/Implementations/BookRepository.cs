using AspNetUnityOfWork.Data.Entities;
using AspNetUnityOfWork.Data.Repositories.Interfaces;

namespace AspNetUnityOfWork.Data.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dataContext;

        public BookRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await _dataContext.Books.FindAsync(id);
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
