using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaUCDB.Data;
using ProvaUCDB.Models;

namespace ProvaUCDB.Services
{
    public class OrderService
    {
        private readonly ProvaUCDBContext _context;

        public OrderService(ProvaUCDBContext context)
        {
            _context = context;
        }

        public List<Order> FindAll()
        {
            return _context.Order.ToList();
        }
    }
}
