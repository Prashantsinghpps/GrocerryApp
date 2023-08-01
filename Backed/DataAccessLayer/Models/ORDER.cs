
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ORDER
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int quantity { get; set; }
        public DateTime date { get; set; }
        public string orderedBy { get; set; }
         public Guid orderId { get; set; }
        public string description { get; set; }
        public string details { get; set; }
        public int productId { get; set; }
        public int orderCount { get; set; }


    }
}
