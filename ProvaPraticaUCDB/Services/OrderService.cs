using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaPraticaUCDB.Data;
using ProvaPraticaUCDB.Models;
using ProvaPraticaUCDB.Models.Enums;
using ProvaPraticaUCDB.Services.Exceptions;

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
            return _context.Order.OrderBy(x => x.DueDate).ToList();
        }

        public void Insert(Order order)
        {
            if (order.DueDate <= DateTime.Now)
            {
                order.Status = OrderStatus.Expired;
            } else
            {
                order.Status = OrderStatus.Valid;
            }

            _context.Add(order);
            _context.SaveChanges();
        }

        public Order FindById(int id)
        {
            return _context.Order.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Order.Find(id);

            _context.Order.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            if (!_context.Order.Any(x => x.Id == order.Id))
            {
                throw new NotFoundException("Este pedido não foi encontrado");
            }

            try
            {
                _context.Update(order);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
