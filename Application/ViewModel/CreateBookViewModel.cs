namespace AspNetUnityOfWork.Application.ViewModel
{
    public class CreateBookViewModel
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }

        public CreateBookViewModel(string name, int authorId)
        {
            Name = name;
            AuthorId = authorId;
        }
    }
}
