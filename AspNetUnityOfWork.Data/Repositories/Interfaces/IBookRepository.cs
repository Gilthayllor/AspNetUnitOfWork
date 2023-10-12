using AspNetUnityOfWork.Data.Entities;

namespace AspNetUnityOfWork.Data.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(int id);

        Task InsertAsync(Book book);
    }
}
