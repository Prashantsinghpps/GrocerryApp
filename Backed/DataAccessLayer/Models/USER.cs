using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class USER
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public long phone { get; set; }
        public string password { get; set; }
        public string confirmPassword{ get; set; }
        //public string isActive { get; set; }

        // public string IsActive { get; set; }
        public string state { get; set; }
    }
}
