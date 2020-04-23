using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Warehouse : IDeleted
    {
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public List<WarehouseProduct> Products { get; set; }
        public bool IsDeleted { get; set; }
    }
}
