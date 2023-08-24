using BookStoreWebApp.DataAccess.Data;
using BookStoreWebApp.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _database;

        public UnitOfWork(AppDbContext database)
        {
            _database = database;
            Category = new CategoryRepository(_database);
            CoverType = new CoverTypeRepository(_database);
            Product = new ProductRepository(_database);
        }
        public ICategoryRepository Category { get; private set; }

        public ICoverTypeRepository CoverType { get; private set; }

        public IProductRepository Product { get; private set; }

        void IUnitOfWork.Save()
        {
            _database.SaveChanges();
        }
    }
}
