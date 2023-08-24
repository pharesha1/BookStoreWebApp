﻿using BookStoreWebApp.DataAccess.Data;
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

        public void Update(CoverType coverType)
        {
            _database.CoverType.Update(coverType);
        }
    }
}
