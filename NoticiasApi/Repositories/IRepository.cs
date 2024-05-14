using NoticiasApi.Models.Entities;

namespace NoticiasApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        ItesrcneOctavoContext Context { get; }

        void Delete(object id);
        void Delete(T entity);
        T? Get(object id);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
    }
}