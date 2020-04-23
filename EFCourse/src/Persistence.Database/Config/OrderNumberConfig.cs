using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class OrderNumberConfig
    {
        public OrderNumberConfig(EntityTypeBuilder<OrderNumber> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Year);
            entityBuilder.HasData(new OrderNumber
            {
                Year = DateTime.Now.Year,
                Value = 0
            });
        }
    }
}
