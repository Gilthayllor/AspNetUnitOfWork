using AspNetUnityOfWork.Data.Repositories.Interfaces;

namespace AspNetUnityOfWork.Data.Repositories.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _dataContext;

        public AuthorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task UpdateBookCountAsync(int authorId)
        {
            var author = await _dataContext.Authors.FindAsync(authorId);
            if (author == null)
                throw new Exception("Author not found.");

            author.BookCount += 1;
        }
    }
}
