using AspNetUnityOfWork.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetUnityOfWork.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public DataContext(DbContextOptions<DataContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(x =>
            {
                x.ToTable("Authors");

                x.HasKey(x => x.Id);

                x.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                x.HasMany<Book>()
                    .WithOne(x => x.Author)
                    .HasForeignKey(x => x.AuthorId);


                x.Property(x => x.Name)
                    .IsRequired(true)
                    .HasMaxLength(100);

                x.Property(x => x.BookCount);
            });

            modelBuilder.Entity<Book>(x =>
            {
                x.ToTable("Books");
                x.HasKey(x => x.Id);

                x.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                x.Property(x => x.Name);
            });
        }
    }
}
