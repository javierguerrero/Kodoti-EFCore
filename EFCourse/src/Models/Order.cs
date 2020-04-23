using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Order
    {
        public string OrderId { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public List<OrderDetail> Items { get; set; }

        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public DateTime RegisteredAt { get; set; }
    }
}
