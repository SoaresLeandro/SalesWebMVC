using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaUCDB.Data;
using ProvaUCDB.Models;

namespace ProvaUCDB.Services
{
    public class ProductService
    {
        private readonly ProvaUCDBContext _context;

        public ProductService(ProvaUCDBContext context)
        {
            _context = context;
        }

        public List<Product> FindAll()
        {
            return _context.Product.OrderBy(x => x.Name).ToList();
        }
    }
}
