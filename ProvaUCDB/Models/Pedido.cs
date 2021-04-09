using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaUCDB.Models.Enums;

namespace ProvaUCDB.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataVencimento { get; set; }
        public double Valor { get; set; }
        public Produto Produto { get; set; }
        public PedidoStatus Status { get; set; }

        public Pedido()
        {
        }

        public Pedido(int id, DateTime dataVencimento, Produto produto, PedidoStatus status)
        {
            Id = id;
            DataVencimento = dataVencimento;
            Produto = produto;
            Status = status;
        }

        public void AplicarDesconto(double valor)
        {
            if (DataVencimento >= new DateTime())
            {
                Valor = Valor += valor;
            }
        }
    }
}
