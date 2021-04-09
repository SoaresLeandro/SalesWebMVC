using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaPraticaUCDB.Data;
using ProvaPraticaUCDB.Models;

namespace ProvaPraticaUCDB.Services
{
    public class OrderService
    {
        private readonly ProvaPraticaUCDBContext _context;

        public OrderService(ProvaPraticaUCDBContext context)
        {
            _context = context;
        }

        public List<Order> FindAll()
        {
            return _context.Order.ToList();
        }
    }
}
