using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetUnityOfWork.Data.Repositories.Interfaces
{
    public interface IUnityOfWorkRepository
    {
        Task<bool> CommitAsync();

        Task Rollback();
    }
}
