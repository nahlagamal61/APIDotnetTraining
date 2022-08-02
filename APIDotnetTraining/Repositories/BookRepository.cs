namespace APIDotnetTraining.Repositories
{
    using APIDotnetTraining.Entities;
    using System.Collections.Generic;

    public class BookRepository : IBaseRepository<Book>
    {
        private readonly ApplicatioDbContext _dbContext;

       // public List<Book> books;

        public BookRepository(ApplicatioDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        
        public Book Create(Book book)
        {
            _dbContext.Set<Book>().Add(book);
            _dbContext.SaveChanges();
            return book;
        }

        public void Delete(int id)
        {
            var book = _dbContext.Set<Book>().SingleOrDefault(b => b.BookId == id);
            _dbContext.Set<Book>().Remove(book);
            _dbContext.SaveChanges();
        }

        public List<Book> FindAll()
        {
            return _dbContext.Set<Book>().ToList();
        }

        public Book FindById(int id)
        {
            return _dbContext.Set<Book>().SingleOrDefault(b => b.BookId == id);
        }

        public Book FindByName(string name)
        {
            return _dbContext.Set<Book>().SingleOrDefault(b => b.BookTitle == name);

        }

        public void Update(int id ,Book book)
        {
            var oldbook = _dbContext.Set<Book>().SingleOrDefault(b => b.BookId == id);
            oldbook.BookTitle = book.BookTitle;
            oldbook.Version = book.Version;
            oldbook.Description = book.Description;
            oldbook.Auther= book.Auther;

            _dbContext.SaveChanges();
        }
    }
}
