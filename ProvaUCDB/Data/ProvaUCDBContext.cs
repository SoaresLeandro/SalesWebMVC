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

        public DbSet<ProvaUCDB.Models.Product> Product { get; set; }
    }
}
