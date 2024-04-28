
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.ValueGeneration.Internal;
using ShoppingCart.Models.EntityFramework;

namespace ShoppingCart.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext db;
        protected readonly DbSet<T> table;
        public Repository(ShoppingCartDbContext context)
        {
            this.db = context;
            this.table = context.Set<T>();
        }
        public T Add(T entity)
        {
            if(entity == null)
                return null;
            
            this.table.Add(entity);
            this.db.SaveChanges();
            return entity;
        }

        public T Delete(T entity, int Id)
        {
            if(entity==null) return null;

            this.table.Remove(entity);
            this.db.SaveChanges();
            return entity;
        }

        public IEnumerable<T> Get()
        {
            return this.table.Select(e=>e).ToList<T>();
        }

        public T Get(int Id)
        {
            return this.table.Find(Id);
        }

        public T Update(T entity, int Id)
        {
            if(entity == null) return null;

            this.table.Attach(entity);
            this.db.Entry(entity).State = EntityState.Modified;
            this.db.SaveChanges();
            return entity;
        }
    }
}