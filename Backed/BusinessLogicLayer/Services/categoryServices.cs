using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
  public  class categoryServices
    {
        //injecting dbContext and using it in our api so that we can fetch and save data to our database
        private readonly ApplicationDbContext _db;
        public categoryServices(ApplicationDbContext db)
        {
            _db = db;

        }
        public IEnumerable<CATEGORY> getAllCategory()
        {
            try
            {
                var categories =  _db.category.ToList();
                return (categories);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
