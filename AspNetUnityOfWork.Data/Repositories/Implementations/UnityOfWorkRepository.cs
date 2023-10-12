using AspNetUnityOfWork.Data.Repositories.Interfaces;

namespace AspNetUnityOfWork.Data.Repositories.Implementations
{
    public class UnityOfWorkRepository : IUnityOfWorkRepository
    {
        private readonly DataContext _dataContext;

        public UnityOfWorkRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CommitAsync()
        {
            return (await _dataContext.SaveChangesAsync()) > 0;
        }

        public Task Rollback()
        {
            _dataContext.ChangeTracker.Clear();
            return Task.CompletedTask;
        }
    }
}
