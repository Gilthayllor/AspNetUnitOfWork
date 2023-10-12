using AspNetUnityOfWork.Data.Repositories.Implementations;
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
        private readonly IUnityOfWorkRepository _unityOfWorkRepository;
    }
}
