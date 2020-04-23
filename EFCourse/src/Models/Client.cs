using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientNumber { get; set; }
        public string Name { get; set; }

        public int? Country_Id { get; set; }

        public Country Country { get; set; }

        public List<Order> Orders { get; set; }
    }
}
