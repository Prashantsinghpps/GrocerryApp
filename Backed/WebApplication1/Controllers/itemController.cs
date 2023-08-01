using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System.Drawing;
using BusinessLogicLayer.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class itemController : Controller
    {
        //injecting dbContext and using it in our api so that we can fetch and save data to our database
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _db;
        private readonly itemServices _itemServices;
        public itemController(ApplicationDbContext db, IWebHostEnvironment env, itemServices itemServices)
        {
            _db = db;
            _environment = env;
            _itemServices = itemServices;
        }






        // we are using this get method to get all items ordered by names as we want to show items in ordered form
        [HttpGet]
        public async Task<IActionResult> getAllItems()
        {

            return Ok(_itemServices.getAllItems());

        }







        //this method returns an item with a particular id...we are using this method to show the detail of a particular item. 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id) //changed
        {

            return Ok(_itemServices.GetProduct(id));
   
        }




         


        //this method we are using to delete an items by its id...this method is used by admins to delete a item
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteItemById(int id)//changed
        {

            return Ok(_itemServices.deleteItemById(id));
        }







//through this method we are updating the item details ...this method would be used by admins only to update the item details.
        [HttpPut]
        public ITEM updateItem()
        { 
    
            string FileName = "";
            bool Result = false;
            var name = Request.Form["name"];
            var details = Request.Form["details"];
            var price = Request.Form["price"];
            var quantity = Request.Form["quantity"];
            var category = Request.Form["category"];
            var description = Request.Form["description"];
            var offer = Request.Form["offer"];
            var id = Request.Form["id"];

            var Files = Request.Form.Files;
            foreach (IFormFile source in Files)
            {
                FileName = source.FileName;
                string imagepath = GetActualpath(FileName);
                try
                {
                    if (!System.IO.Directory.Exists(imagepath))
                        System.IO.Directory.CreateDirectory(imagepath);

                    string Filepath = imagepath + "\\1.png";

                    if (System.IO.File.Exists(Filepath))
                        System.IO.File.Delete(Filepath);

                    using (FileStream stream = System.IO.File.Create(Filepath))
                    {
                         source.CopyTo(stream);
                        Result = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            var item = _db.item.Find(int.Parse(id));
            string hosturl = "https://localhost:44369";
            item.image = hosturl + "/Uploads/Product/" + FileName + "/1.png";
            item.name = name;
            item.details = details;
            item.category = category;
            item.description = details;
            item.mrp = (int.Parse(price));
            item.quantity = (int.Parse(quantity));
            item.description = description;
            item.offer = (int.Parse(offer));
             _db.item.Update(item);
             _db.SaveChanges();



            return (item);
        }







        // through this method we are saving an item to database ...this method is used by admin only.
        [HttpPost("UploadItem")]
        public async Task<ActionResult> UploadItem()
        {
            string FileName = "";
            bool Result = false;
            var name = Request.Form["name"];
            var details = Request.Form["details"];
            var price = Request.Form["price"];
            var quantity = Request.Form["quantity"];
            var category = Request.Form["category"];
            var description = Request.Form["description"];
            var offer = Request.Form["offer"];


            var Files = Request.Form.Files;
            foreach (IFormFile source in Files)
            {
                FileName = source.FileName;
                string imagepath = GetActualpath(FileName);
                try
                {
                    if (!System.IO.Directory.Exists(imagepath))
                        System.IO.Directory.CreateDirectory(imagepath);

                    string Filepath = imagepath + "\\1.png";

                    if (System.IO.File.Exists(Filepath))
                        System.IO.File.Delete(Filepath);

                    using (FileStream stream = System.IO.File.Create(Filepath))
                    {
                        await source.CopyToAsync(stream);
                        Result = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            ITEM item = new ITEM();
            string hosturl = "https://localhost:44369";
            item.image = hosturl + "/Uploads/Product/" + FileName + "/1.png";
            item.name = name;
            item.details = details;
            item.category = category;
            item.description = details;
            item.mrp = (int.Parse(price));
            item.quantity = (int.Parse(quantity));
            item.description = description;
            item.offer = (int.Parse(offer));
            //add its category to category table
            CATEGORY newCategory = new CATEGORY();
            var obj = _db.category.FirstOrDefault(i => i.name == item.category);
            if (obj == null)
            {
                newCategory.name = item.category;
                await _db.category.AddAsync(newCategory);
               
            }
            await _db.item.AddAsync(item);
            await _db.SaveChangesAsync();

            return Ok(item.id);

        }








        // through this method we are getting all items in the item table.
        [HttpGet("GetAllItems")]
        public IEnumerable<ITEM> GetAllItems()
        {

            return (_itemServices.getAllItems());
        }






        // this is a nonAction method and this is being used get the actual path of the string
        [NonAction]
        public string GetActualpath(string FileName)
        {
            return _environment.WebRootPath + "\\Uploads\\Product\\" + FileName;
        }





    }
}
      













