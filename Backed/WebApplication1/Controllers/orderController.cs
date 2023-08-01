using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using BusinessLogicLayer.Services;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class orderController : Controller
    {
        private readonly orderServices _orderServices;

        //injecting dbContext and using it in our api so that we can fetch and save data to our database
        private readonly ApplicationDbContext _db;

        public orderController(ApplicationDbContext db, orderServices orderServices)
        {
            _db = db;
            _orderServices = orderServices;
        }








        //through this method we are getting all orders that have been places and in front-end we would be using this data accordingly
        [HttpGet]
        public async Task<IActionResult> getAllOrders()
        {

          return Ok(_orderServices.getAllOrders());
        }







        //this method is being used for deleting the data of order table
        [HttpDelete]
        public string deleteOrder()
        {

           return  _orderServices.deleteOrder();
        }




    }
}
