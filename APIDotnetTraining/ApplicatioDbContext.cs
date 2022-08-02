namespace APIDotnetTraining
{
    using APIDotnetTraining.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicatioDbContext: DbContext
    {
        public ApplicatioDbContext(DbContextOptions<ApplicatioDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reader>()
                .HasOne<Reader>()
                .WithMany();
            
            modelBuilder.Entity<Book>().HasData(new List<Book> {
                new Book{ BookId=1, BookTitle = "Book 1", Description = "Book 1 description", Version = 2, Auther = "auther 1" },
                new Book{ BookId=2, BookTitle ="Book 2" , Description ="Book 2 description" , Version = 2 , Auther ="auther 2" },
                new Book{ BookId=3, BookTitle ="Book 3" , Description ="Book 3 description" , Version = 2 , Auther ="auther 3" },
                new Book{ BookId=4, BookTitle ="Book 4" , Description ="Book 4 description" , Version = 2 , Auther ="auther 4" }

            }) ;
            modelBuilder.Entity<Reader>().HasData(new List<Reader>
            {
                new Reader {ID=1, Name = "reader 1" , Age = 22 ,BookId =1  },
                new Reader {ID=2, Name = "reader 1" , Age = 44 , BookId = 2}
            });

        }
    }
}
