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
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly AppDbContext _database;

        public OrderHeaderRepository(AppDbContext database) : base(database)
        {
            _database = database;
        }

        public void Update(OrderHeader company)
        {
            _database.OrderHeader.Update(company);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderHeaderFromDatabase = _database.OrderHeader.FirstOrDefault(u=>u.Id==id);
            if (orderHeaderFromDatabase != null)
            {
                orderHeaderFromDatabase.OrderStatus = orderStatus;
                if (paymentStatus != null)
                {
                    orderHeaderFromDatabase.PaymentStatus = paymentStatus;
                }
            }
        }
    }
}
