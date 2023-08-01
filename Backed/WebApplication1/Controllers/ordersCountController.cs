using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ordersCountController : Controller
    {

        private readonly ordersCountServices _ordersCountServices;

        public ordersCountController(ordersCountServices ordersCountServices)
        {
            _ordersCountServices = ordersCountServices;
        }









        // through this method we are deleting all the data from ordersCount table.
        [HttpDelete]
        public string deleteOrdersCount()
        {

            return _ordersCountServices.deleteOrdersCount();
        }








        // this method is responsible for sending the data and using this data in front-end we are showing what are the top 5 products ordered in a particular year and month.
        [HttpGet]
        public async Task<ActionResult>getAllOrdersCount()
        {

            return Ok(_ordersCountServices.getAllOrdersCount());
        }





    }
}
