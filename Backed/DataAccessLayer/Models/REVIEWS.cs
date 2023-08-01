using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
 public  class REVIEWS
    {

        [Key]
        public int id { get; set; }
        public int productId { get; set; }
        public string review { get; set; }
        public string reviewedBy { get; set; }
    }
}
