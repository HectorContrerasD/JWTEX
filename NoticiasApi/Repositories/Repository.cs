using NoticiasApi.Models.Entities;

namespace NoticiasApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(ItesrcneOctavoContext context)
        {
            Context = context;
        }

        public ItesrcneOctavoContext Context { get; }


        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }
        public virtual T? Get(object id)
        {
            return Context.Find<T>(id);
        }

        public virtual void Insert(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(object id) /*por si se elimina solo con id*/
        {
            var entity = Get(id);
            if (entity != null)
            {
                Delete(entity);
            }

        }
    }
}
