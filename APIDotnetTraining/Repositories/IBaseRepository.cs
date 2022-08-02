namespace APIDotnetTraining.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> FindAll();

        T FindById(int id);

        T FindByName(string name);

        void Update(int id, T entity);

        T Create(T entity);

        void Delete(int id);

    }
}
