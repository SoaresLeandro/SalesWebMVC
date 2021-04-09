using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaPraticaUCDB.Models.Enums;

namespace ProvaPraticaUCDB.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime DueDate { get; set; }
        public Product Product { get; set; }
        public OrderStatus Status { get; set; }

        public Order()
        {
        }

        public Order(int id, double value, DateTime dueDate, Product product, OrderStatus status)
        {
            Id = id;
            Value = value;
            DueDate = dueDate;
            Product = product;
            Status = status;
        }

        public void ApplyDiscount(double value)
        {
            if (DueDate >= new DateTime)
            {
                Value -= value;
            }
        }
    }
}
