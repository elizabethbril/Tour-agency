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

        public void Clear()
        {
            DbSet.RemoveRange(DbSet);
            Context.SaveChanges();

        }
        public void Delete(int Id)
        {
            DbSet.Remove(DbSet.Find(Id));
            Context.SaveChanges();
        }
        public void Delete(T Item)
        {
            Context.Entry(Item).State = EntityState.Deleted;
            Context.SaveChanges();
        }
        public void Add(T Item)
        {
            DbSet.Add(Item);
            Context.SaveChanges();
        }
        public void Modify(int Id, T Item)
        {
            Context.Entry(Context.Set<T>().Find(Id)).CurrentValues.SetValues(Item);
            Context.SaveChanges();
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

