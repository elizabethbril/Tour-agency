using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext Context;
        private DbSet<T> DbSet;
        public GenericRepository(DbContext Context)
        {
            this.Context = Context;
            DbSet = Context.Set<T>();
        }
        
        public void Delete(object Id)
        {
            DbSet.Remove(DbSet.Find(Id));
            Context.SaveChanges();
        }
        public void Delete(T Item)
        {
            Context.Entry(Item).State = EntityState.Deleted;
            Context.SaveChanges();
        }
        public void Add(T item)
        {
            DbSet.Add(item);
        }
        public void Modify(object id, T newItem)
        {
            Context.Entry(DbSet.Find(id)).CurrentValues.SetValues(newItem);
            Context.Entry(DbSet.Find(id)).State = EntityState.Modified;
        }
        public T Get(int Id)
        {
            return DbSet.Find(Id);
        }

        public T GetByPosition(int Position)
        {
            return DbSet.ToList()[Position];
        }

        public List<T> GetAll()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public List<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbSet;
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public List<T> GetAll(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = DbSet.Where(predicate).AsQueryable();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

