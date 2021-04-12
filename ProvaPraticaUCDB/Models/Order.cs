using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProvaPraticaUCDB.Models.Enums;

namespace ProvaPraticaUCDB.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name = "Nome do Produto")]
        public string NameProduct { get; set; }
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Value { get; set; }
        [Display(Name = "Data de Vencimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
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

    }
}
