namespace AspNetUnityOfWork.Data.Repositories.Interfaces
{
    internal interface IAuthorRepository
    {
        Task UpdateBookCountAsync(int idAuthor);
    }
}
