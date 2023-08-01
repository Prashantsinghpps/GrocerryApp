using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
   public class ordersCountServices
    {
        //injecting dbContext and using it in our api so that we can fetch and save data to our database
        private readonly ApplicationDbContext _db;
        public ordersCountServices(ApplicationDbContext db)
        {

            _db = db;
        }


        public string deleteOrdersCount()
        {
            try
            {
                _db.ordersCount.RemoveRange(_db.ordersCount);
                _db.SaveChanges();
                return "deleted";
            }
            catch (Exception ex) { throw ex; }
        }

        public IEnumerable<ORDERSCOUNT> getAllOrdersCount()
        {
            try
            {

                var list =  _db.ordersCount.OrderByDescending(u => u.orderCount).ToList();
                return (list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
