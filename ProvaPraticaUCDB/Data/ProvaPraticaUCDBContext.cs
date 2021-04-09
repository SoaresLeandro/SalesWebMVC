using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaPraticaUCDB.Models;

namespace ProvaPraticaUCDB.Data
{
    public class ProvaPraticaUCDBContext : DbContext
    {
        public ProvaPraticaUCDBContext (DbContextOptions<ProvaPraticaUCDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
