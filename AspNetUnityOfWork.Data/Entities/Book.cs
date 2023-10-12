namespace AspNetUnityOfWork.Data.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;

        public Book(string name, int authorId)
        {
            Name = name;
            AuthorId = authorId;
        }
    }
}
