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
    public class reviewController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly reviewServices _reviewservices;
        public reviewController(reviewServices  reviewservices, ApplicationDbContext db)
        {
            _reviewservices = reviewservices;
            _db = db;
        }






        // this method is responsible for saving the review which is being posted by the user.
       [HttpPost]
       public string saveReview(REVIEWS reviewobj)
        {

            return (_reviewservices.saveReview(reviewobj));
        }






        //this method is returning the reviews on a particular item using its productId
        [HttpGet("{id}")]
        public List<REVIEWS> getReviewsById(int?id)
        {

             return (_reviewservices.getReviewsById(id));
        }






        // this method is responsible to delete all the reviews 
        [HttpDelete]
        public string deleteAllReviews()
        {

            return _reviewservices.deleteAllReviews();
        }




    }
}
