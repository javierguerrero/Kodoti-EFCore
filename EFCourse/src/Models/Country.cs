using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public List<Client> Clients { get; set; }
    }
}
