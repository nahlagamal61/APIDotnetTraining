namespace APIDotnetTraining.Repositories
{
    using APIDotnetTraining.Entities;
    using System.Collections.Generic;

    public class ReaderRepository : IBaseRepository<Reader>
    {
        private readonly ApplicatioDbContext _dbContext;

        public ReaderRepository(ApplicatioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Reader Create(Reader reader)
        {
            _dbContext.Set<Reader>().Add(reader);
            _dbContext.SaveChanges();
            return reader;
        }
        
        public List<Reader> FindAll()
        {
            return _dbContext.Set<Reader>().ToList();
        }

        public Reader FindByName(string name)
        {
            var reader = _dbContext.Set<Reader>().SingleOrDefault(r => r.Name.Contains(name));

            return reader;

        }
        
        public Reader FindById(int id)
        {
            var reader = _dbContext.Set<Reader>().SingleOrDefault(r => r.ID == id);
            return reader;
        }
        
        public void Update(int id, Reader reader)
        {
            var reader1 = _dbContext.Set<Reader>().SingleOrDefault(r => r.ID == id);
            reader1.Age = reader.Age;
            reader1.Name = reader1.Name;
            reader1.Books = reader.Books;

        }
        
        public void Delete(int id)
        {
            var reader = _dbContext.Set<Reader>().SingleOrDefault(r => r.ID == id);
            _dbContext.Set<Reader>().Remove(reader);
            _dbContext.SaveChanges();
            
        }

    }
}
