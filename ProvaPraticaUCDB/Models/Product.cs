using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaPraticaUCDB.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, Order order)
        {
            Id = id;
            Name = name;
            Order = order;
        }
    }
}
