using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
   public class orderServices
    {
        private readonly ApplicationDbContext _db;
        public orderServices(ApplicationDbContext db)
        {
            _db = db;
        }



        public IEnumerable<ORDER> getAllOrders()
        {
            try
            {
                var orders =  _db.order.ToList();
                return (orders);
            }
            catch (Exception ex) { throw ex; }
        }







        public string deleteOrder()
        {
            try
            {

                _db.order.RemoveRange(_db.order);
                _db.SaveChanges();
                return "deleted";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
