using AspNetUnityOfWork.Data.Entities;

namespace AspNetUnityOfWork.Data.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task UpdateBookCountAsync(int auhtorId);
    }
}
