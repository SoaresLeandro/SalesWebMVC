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

        public async Task<List<Order>> FindAllAsync()
        {
            return await _context.Order.OrderBy(x => x.DueDate).ToListAsync();
        }

        public async Task InsertAsync(Order order)
        {
            calculateExpiration(order);

            _context.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> FindByIdAsync(int id)
        {
            return await _context.Order.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Order.FindAsync(id);

            _context.Order.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsyn(Order order)
        {
            bool hasAny = await _context.Order.AnyAsync(x => x.Id == order.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Este pedido não foi encontrado");
            }

            try
            {
                calculateExpiration(order);
                _context.Update(order);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public void calculateExpiration(Order order)
        {
            DateTime now = DateTime.Today;
            TimeSpan ts = now.Subtract(order.DueDate);

            if (ts.Days >= 0)
            {
                order.Status = OrderStatus.Expired;
            }
            else if (ts.Days < 0 && ts.Days >= -3)
            {
                order.Status = OrderStatus.CloseExpiration;
            }
            else if (ts.Days < -3)
            {
                order.Status = OrderStatus.Valid;
            }
        }

        public async Task<int> ApplyDiscountAsync(Order order)
        {
            calculateExpiration(order);

            if (order.Status == OrderStatus.Expired)
            {
                return 0;
            }
            
            try {
                Order orderSearch = await _context.Order.FindAsync(order.Id);
                double value = orderSearch.Value;
                double MaximumDiscount = value *= 0.3;

                if (order.Value > MaximumDiscount)
                {
                    return 1;
                }

                orderSearch.Value -= order.Value;

                _context.Update(orderSearch);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            return 2;
        }
    }
}
