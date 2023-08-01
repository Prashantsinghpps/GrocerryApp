using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
  public  class reviewServices
    {
        //injecting dbContext and using it in our api so that we can fetch and save data to our database
        private readonly ApplicationDbContext _db;
        public reviewServices(ApplicationDbContext db)
        {

            _db = db;
        }

        public string saveReview(REVIEWS reviewobj)
        {
            try
            {
                REVIEWS newReview = new REVIEWS();
                newReview.productId = reviewobj.id;
                newReview.review = reviewobj.review;
                _db.review.Add(newReview);
                _db.SaveChanges();
                return "review successfully added";
            }
            catch (Exception ex) { throw ex; }
        }




        public List<REVIEWS> getReviewsById(int? ProductId)
        {
            List<REVIEWS> selectedReviews = new List<REVIEWS>();
            try
            {

                var list = _db.review.ToList();

                foreach (var review in list)
                {
                    if (review.productId == ProductId)
                    {
                        selectedReviews.Add(review);
                    }

                }
                return (selectedReviews);
            }
            catch (Exception ex)
            {
                return new List<REVIEWS>(); // Return an empty list
            }

        }



        public string deleteAllReviews()
        {
            try
            {
                _db.review.RemoveRange(_db.review);
                _db.SaveChanges();
                return "all reviews have been deleted";
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
