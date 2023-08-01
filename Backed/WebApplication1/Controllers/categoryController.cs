using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
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
    public class categoryController : Controller
    {


        private readonly categoryServices _categoryServices;
        public categoryController(categoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }




        //through this method we are returning all categories present in category table so,that we can display these categories in our dropdown
        [HttpGet]
        public async Task<ActionResult> getAllCategory()
        {

            return Ok(_categoryServices.getAllCategory());
        }

    }
}
