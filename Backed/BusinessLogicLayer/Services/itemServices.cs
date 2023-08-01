using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
   public class itemServices
    {
        //injecting dbContext and using it in our api so that we can fetch and save data to our database

        private readonly ApplicationDbContext _db;
        public itemServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public  IEnumerable<ITEM> getAllItems()
        {
            try
            {
                var users =  _db.item.OrderBy(u => u.name).ToList();

                return (users);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ITEM  GetProduct(int id) //changed
        {
            try
            {
                ITEM product =  _db.item.FirstOrDefault(p => p.id == id);
                return (product);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string deleteItemById(int id)//changed
        {
            try
            {
                var item = _db.item.Find(id);
                if (item != null)
                    _db.item.Remove(item);

                //here we are also  deleting the orderCount of a particular item.
                ORDERSCOUNT itemInOrdersCountTable = _db.ordersCount.FirstOrDefault(u => u.productId == id);
                if (itemInOrdersCountTable != null)
                {
                    _db.ordersCount.Remove(itemInOrdersCountTable);
                }
                _db.SaveChangesAsync();
                return ("deleted");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IEnumerable<ITEM> GetAllItems()
        {
            try
            {
                var _product = _db.item.ToList();
                return _product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
