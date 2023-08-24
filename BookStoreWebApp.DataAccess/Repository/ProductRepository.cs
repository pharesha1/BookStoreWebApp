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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _database;

        public ProductRepository(AppDbContext database) : base(database)
        {
            _database = database;
        }

        public void Update(Product product)
        {
            var productFromDb = _database.Product.FirstOrDefault(u=>u.Id==product.Id);
            if(productFromDb != null)
            {
                productFromDb.Title = product.Title;
                productFromDb.ISBN = product.ISBN;
                productFromDb.ListPrice = product.ListPrice;
                productFromDb.Price = product.Price;
                productFromDb.Price50 = product.Price50;
                productFromDb.Price100 = product.Price100;
                productFromDb.Description = product.Description;
                productFromDb.Author = product.Author;
                productFromDb.CategoryId = product.CategoryId;
                productFromDb.CoverTypeId = product.CoverTypeId;
                if(product.ImageURL != null )
                {
                    productFromDb.ImageURL = product.ImageURL;
                }
            }
        }
    }
}
