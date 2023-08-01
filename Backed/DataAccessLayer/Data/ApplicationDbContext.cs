
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<USER> user { get; set; }
        public DbSet<CART> cart { get; set; }
        public DbSet<ITEM> item { get; set; }
        public DbSet<ORDER> order { get; set; }
        public DbSet<IMAGE> image { get; set; }
        public DbSet<CATEGORY> category { get; set; }
        public DbSet<REVIEWS> review { get; set; }
        public DbSet<ORDERCOUNT> orderCount { get; set; }
        public DbSet<ORDERSCOUNT> ordersCount { get; set; }

    }
}

