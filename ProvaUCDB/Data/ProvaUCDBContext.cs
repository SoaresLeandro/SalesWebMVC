using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaUCDB.Models;

namespace ProvaUCDB.Data
{
    public class ProvaUCDBContext : DbContext
    {
        public ProvaUCDBContext (DbContextOptions<ProvaUCDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
