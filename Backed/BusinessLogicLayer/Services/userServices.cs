using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
 public  class userServices
    {
        private readonly ApplicationDbContext _db;
        public userServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<USER> getAllUsers()
        {
            try
            {
                var users =  _db.user.ToList();
                return (users);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public  USER CheckUser( USER obj)  
        {
            try
            {
                var user =  _db.user.FirstOrDefault(u => u.email == obj.email && u.password == obj.password);
                if (user != null)
                {
                    //if any user did not logout and he left some items in the cart , so items in the cart  must be removed for this new user.
                    _db.cart.RemoveRange(_db.cart);
                    user.state = "active";
                    _db.SaveChanges();
                }
                return (user);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public USER getUserById(Guid id) 
        {
            try
            {
                var user =  _db.user.Find(id);
                return (user);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public USER logoutUser( USER obj)  
        {
            try
            {
                var user =  _db.user.FirstOrDefault(u => u.id == obj.id);
                _db.cart.RemoveRange(_db.cart);
                if (user != null)
                {
                    user.state = "inactive";
                     _db.SaveChanges();
                }
                return (user);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string anonymous()
        {
            try
            {
                var user =  _db.user.FirstOrDefault(u => u.state == "active");
                if (user == null)
                    return "anonymous";
                return "some one is logged in";
            }
            catch (Exception ex) { throw ex; }

        }

    }
}
