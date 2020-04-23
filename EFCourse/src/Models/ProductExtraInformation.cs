using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ProductExtraInformation
    {
        public int ProductExtraInformationId { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
