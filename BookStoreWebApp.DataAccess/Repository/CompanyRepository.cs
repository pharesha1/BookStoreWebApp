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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly AppDbContext _database;

        public CompanyRepository(AppDbContext database) : base(database)
        {
            _database = database;
        }

        public void Update(Company company)
        {
            var companyFromDb = _database.Company.FirstOrDefault(u=>u.Id==company.Id);
            if (companyFromDb != null)
            {
                companyFromDb.Name = company.Name;
                companyFromDb.State = company.State;
                companyFromDb.City = company.City;
                companyFromDb.StreetAddress = company.StreetAddress;
                companyFromDb.PostalCode = company.PostalCode;
                companyFromDb.PhoneNumber = company.PhoneNumber;
            }
        }
    }
}
