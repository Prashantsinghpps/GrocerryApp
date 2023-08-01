using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
   public  class ORDERCOUNT
    {
        [Key]
        public int year { get; set; }
        public int month { get; set; }
        public int productId { get; set; }
        public int orderCount { get; set; }
    }
}
