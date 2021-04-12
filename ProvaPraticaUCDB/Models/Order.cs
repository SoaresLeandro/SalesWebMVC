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
        public string NameProduct { get; set; }
        public double Value { get; set; }
        public DateTime DueDate { get; set; }
        public OrderStatus Status { get; set; }

        public Order()
        {
        }

        public Order(int id, string nameProduct, double value, DateTime dueDate, OrderStatus status)
        {
            Id = id;
            NameProduct = nameProduct;
            Value = value;
            DueDate = dueDate;
            Status = status;
        }

        public void ApplyDiscount(double value)
        {
            if (DueDate <= DateTime.Now)
            {
                Value -= value;
            }
        }
    }
}
