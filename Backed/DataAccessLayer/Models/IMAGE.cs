using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class IMAGE
    {
        [Key]
        public int id { get; set; }
        public string image { get; set; }
        public string category { get; set; }
    }
}
