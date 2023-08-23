using BookStoreWebApp.DataAccess.Data;
using BookStoreWebApp.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApp.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _database;
        internal DbSet<T> databaseSet;

        public Repository(AppDbContext database)
        {
            _database = database;
            this.databaseSet = _database.Set<T>();
        }

        void IRepository<T>.Add(T entity)
        {
            databaseSet.Add(entity);
        }

        void IRepository<T>.Delete(T entity)
        {
            databaseSet.Remove(entity);
        }

        void IRepository<T>.DeleteRange(IEnumerable<T> entities)
        {
            databaseSet.RemoveRange(entities);
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            IQueryable<T> query = databaseSet;
            return query.ToList();
        }

        T IRepository<T>.GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = databaseSet;

            query = query.Where(filter);

            return query.FirstOrDefault();
        }
    }
}
