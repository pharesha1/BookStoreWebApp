using BookStoreWebApp.DataAccess.Data;
using BookStoreWebApp.DataAccess.Repository.IRepository;
using BookStoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApp.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly AppDbContext _database;

        public CoverTypeRepository(AppDbContext database) : base(database)
        {
            _database = database;
        }

        public void Add(CoverType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CoverType entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<CoverType> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CoverType> GetAll()
        {
            throw new NotImplementedException();
        }

        public CoverType GetFirstOrDefault(Expression<Func<CoverType, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(CoverType coverType)
        {
            throw new NotImplementedException();
        }
    }
}
