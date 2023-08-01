
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using BusinessLogicLayer.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class userController : Controller
    {
        //injecting dbContext and using it in our api so that we can fetch and save data to our database
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _config;
      private readonly userServices _userServices;
        public userController(ApplicationDbContext db , IConfiguration config, userServices userServices)
        {
            _db = db;
            _config = config;
            _userServices = userServices;
        }






        // this method is responsible to send all users to front-end and there we are using this data to match the user and getting all its credentials.
        [HttpGet]
        public async Task<IActionResult> getAllUsers()
        {

          return Ok(_userServices.getAllUsers());
           
        }








        // though this method we are adding new user to our database 
        [HttpPost]
        public async Task<IActionResult> addUser([FromBody] USER userRequest)
        {
            try
            {
                var user = _db.user.FirstOrDefault(u => u.email == userRequest.email);
                if (user != null)
                    return Ok("Email is already registered");

                userRequest.id = Guid.NewGuid();
                await _db.user.AddAsync(userRequest);
                await _db.SaveChangesAsync();
                return Ok(userRequest);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An error occurred while adding the user");
            }
        }








        //in this method we are matching the credentials of the user and changing the state of that user to "active"
        //to show that user is loggedin and we are using this later.
       [HttpPost("login")]
        public async Task<IActionResult> checkUser([FromBody] USER obj)   //changed
        {

            return Ok(_userServices.CheckUser(obj));


        }
       








        // thorugh this method we are getting a particular used by its id ..and we are using its details accordingly.

        [HttpGet("{id}")]
        public async Task<IActionResult> getUserById(Guid id)   // changed
        {

            return Ok(_userServices.getUserById(id));
            }








            // this method is responsible for logging out the user and changing its state to "inactive"
            [HttpPost("logout")]
        public async Task<IActionResult> logoutUser([FromBody] USER obj)  //changed
        {

            return Ok(_userServices.logoutUser(obj));

        }








        //this method checks whether anyone is logged in or not and sending the result accordingly.
        [HttpGet("anonymous")]
        public async Task<String> anonymous()
        {

            return (_userServices.anonymous());
        
        }







    }
}
