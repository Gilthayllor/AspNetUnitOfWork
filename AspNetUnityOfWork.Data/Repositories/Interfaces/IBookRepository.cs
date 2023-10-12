using AspNetUnityOfWork.Data.Entities;

namespace AspNetUnityOfWork.Data.Repositories.Interfaces
{
    internal interface IBookRepository
    {
        Task<Book> GetByIdAsync(int id);

        Task<Book> InsertAsync(Book book);
    }
}
