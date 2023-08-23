using BookStoreWebApp.DataAccess.Data;
using BookStoreWebApp.DataAccess.Repository.IRepository;
using BookStoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApp.DataAccess.Repository
{
    public class CategoryRepository : Repository<Categories>, ICategoryRepository
    {
        private readonly AppDbContext _database;

        public CategoryRepository(AppDbContext database) : base(database)
        {
            _database = database;
        }

        void ICategoryRepository.Update(Categories category)
        {
            _database.Categories.Update(category);
        }
    }
}
