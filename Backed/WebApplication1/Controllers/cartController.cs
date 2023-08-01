using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System.Text.Json;
using BusinessLogicLayer;
using BusinessLogicLayer.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class cartController : Controller
    {
          private readonly cartServices _cartServices;

        //injecting dbContext and using it in our api so that we can fetch and save data to our database
        private readonly ApplicationDbContext _db;

        public cartController(ApplicationDbContext db, cartServices cartServices)
        {
            _db = db;
            _cartServices = cartServices;
        }





        // saveItemToCart is used to save new item to the cart table
        [HttpPost]
        public CART saveItemToCart(ITEM obj)
        {

             return  _cartServices.saveItemToCart(obj);

        }






        //getAllItems method is used to getAll data from cart table 

        [HttpGet]
        public async Task<IActionResult> getAllItems()
        {

            var result =_cartServices.getAllItems();
            return Ok(result);

        }









        // deleteItem is being used to delete a particular item from cart table using its id

        [HttpDelete("{id}")]
        public CART deleteItem(int id)
        {

           return (_cartServices.deleteItem(id));
        }






        //this is a method to update the order table as once we place order all items from cart should be get erased and should be saved to order table

        [HttpPost("placeOrder")]
        public async Task<IActionResult> placeOrder([FromBody] JsonElement requestdata)
        {
            string orderedBy="";
            try
            {
                if (requestdata.TryGetProperty("orderedBy", out JsonElement orderedByProperty))
                {
                    if (orderedByProperty.ValueKind == JsonValueKind.String)
                    {
                         orderedBy = orderedByProperty.GetString();
                        // Use the 'orderedBy' value as needed
                        // Rest of the code...
                    }
                }
                var cartItems = await _db.cart.ToListAsync();
                Guid orderId = Guid.NewGuid();
                foreach (var item in cartItems)
                {
                    ITEM matchedItem = await _db.item.FirstOrDefaultAsync(u => u.name == item.name);
                    int itemQty = matchedItem.quantity;
                    itemQty -= item.quantity;
                    if (itemQty <= 0)
                    {

                        itemQty = 0;

                    }
                    var todayDate = DateTime.Today;
                    ORDER newOrder = new ORDER();
                    newOrder.image = item.image;
                    newOrder.quantity = item.quantity;
                    newOrder.name = item.name;
                    newOrder.date = todayDate;
                  //  var currentUser = await _db.user.FirstOrDefaultAsync(u => u.state == "active");
                    newOrder.orderedBy = orderedBy;
                    newOrder.orderId = orderId;
                    newOrder.description = item.description;
                    newOrder.details = item.details;
                    newOrder.productId = item.productId;
                    _db.order.Add(newOrder);
                    matchedItem.quantity = itemQty;
                    _db.cart.Remove(item);
                    int year = todayDate.Year;
                    int month = todayDate.Month;
                    int productId = item.productId;
                    var ordersCount = _db.ordersCount.FirstOrDefault(i => i.year == year && i.month == month && i.productId == productId);
                    if (ordersCount != null)
                    {
                        //we have encountered an item whose entry is already in the same year and same month so we just increase the quantity of ordercount.
                        var count = ordersCount.orderCount;
                        count += item.quantity;
                        ordersCount.orderCount = count;
                    }
                    else
                    {
                        //we have to create a new row for this as either year is diff either month is diff either productId is diff .

                        ORDERSCOUNT newOrdersCount = new ORDERSCOUNT();
                        newOrdersCount.year = year;
                        newOrdersCount.month = month;
                        newOrdersCount.productId = productId;
                        newOrdersCount.orderCount = item.quantity;
                        await _db.ordersCount.AddAsync(newOrdersCount);
                    }
                }
                await _db.SaveChangesAsync();
                return Ok(orderId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }





    }
}
