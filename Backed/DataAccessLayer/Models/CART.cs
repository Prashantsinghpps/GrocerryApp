﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class CART
    {
       [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int offer { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string details { get; set; }
        public string category { get; set; }
        public  string description { get; set; }
        public int productId { get; set; }



    }
}
