using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class cartServices
    {
        private readonly ApplicationDbContext _db;
        public cartServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public CART saveItemToCart(ITEM obj)
        {
            try
            {

                var newObj = new CART();
                newObj.name = obj.name;
                newObj.image = obj.image;
                newObj.offer = obj.offer;
                newObj.price = obj.mrp;
                newObj.quantity = obj.quantity;
                newObj.productId = obj.id;
                _db.cart.Add(newObj);
                _db.SaveChanges();
                return newObj;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public IEnumerable<CART> getAllItems()
        {
            try
            {
                var cartitems =  _db.cart.ToList();
                return (cartitems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CART deleteItem(int id)
        {
            try
            {

                CART item = _db.cart.Find(id);
                if (item != null)
                {
                    var res = _db.cart.Remove(item);
                }

                _db.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
