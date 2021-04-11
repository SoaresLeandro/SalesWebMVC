using System;
using ProvaUCDB.Models.Enums;

namespace ProvaUCDB.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime DueDate { get; set; }
        public int MyProperty { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public OrderStatus Status { get; set; }

        public Order()
        {
        }

        public Order(int id, double value, DateTime dueDate, int myProperty, Product product, OrderStatus status)
        {
            Id = id;
            Value = value;
            DueDate = dueDate;
            MyProperty = myProperty;
            Product = product;
            Status = status;
        }
    }
}
