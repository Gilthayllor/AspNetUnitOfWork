namespace AspNetUnityOfWork.Data.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public int BookCount { get; set; }

        public virtual List<Book> Books { get; set; } = null!;

        public Author(string name)
        {
            Name = name;
        }
    }
}
